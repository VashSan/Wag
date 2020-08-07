using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using Wag.Domain.Search;
using Wag.Interface.Search;

namespace Wag.Test.Domain.Search
{
	public class IndexTest
	{
		Index<IIndexableItem> index;

		[SetUp]
		public void Setup()
		{
			index = new Index<IIndexableItem>();
		}

		[Test]
		public void GetAllIndexedItems_ReturnsAddedItems()
		{
			// Arrange
			var item1 = GetItemMock( "1" );
			index.Add( item1 );

			var item2 = GetItemMock( "2" );
			index.Add( item2 );

			// Act
			var allItems = index.GetAllIndexedItems();

			// Assert
			Assert.That( allItems, Is.SupersetOf( new[] { item1, item2 } ) );
		}


		[Test]
		public void Add_NewItem_IsBeingIndexed()
		{
			// Arrange
			var item = new Mock<IIndexableItem>();

			// Act
			index.Add( item.Object );

			// Assert
			item.Verify( m => m.GetKeywords(), Times.Once );
		}

		[Test]
		public void Add_ExistingItem_DoesNotAddDuplicate()
		{
			// Arrange
			var item1 = GetItemMock( "keyword" );
			index.Add( item1 );
			index.Add( item1 );

			// Act
			var allItems = index.GetAllIndexedItems();

			// Assert
			Assert.That( allItems, Has.Exactly( 1 ).Items );
		}

		[Test]
		public void Clear_EmptyIndex_DoesNotThrow()
		{
			// Arrange
			Assert.That( index.GetAllIndexedItems(), Is.Empty );

			// Act
			void Actor()
			{
				index.Clear();
			}

			// Assert
			Assert.That( Actor, Throws.Nothing );
		}

		[Test]
		public void Clear_IndexWithItem_RemovesItem()
		{
			// Arrange
			var item1 = GetItemMock( "keyword" );
			index.Add( item1 );

			// Act
			index.Clear();

			// Assert
			Assert.That( index.GetAllIndexedItems(), Is.Empty );
		}

		[TestCase( "keyword", "keyword", Description = "exact match" )]
		[TestCase( "KeyWorD", "Keyword", Description = "case insensitivity" )]
		[TestCase( "key", "Keyword", Description = "Starts with" )]
		[TestCase( "wor", "keyword", Description = "Contains" )]
		public void Search_ExistingItems_ReturnsMatch( string query, string keyword )
		{
			// Arrange
			var item1 = GetItemMock( keyword );
			index.Add( item1 );

			// Act
			var result = index.Search( query );

			// Assert
			Assert.That( result, Has.Exactly( 1 ).Items );
		}

		[Test]
		[SuppressMessage( "ReSharper", "PossibleMultipleEnumeration" )]
		public void Search_ItemsInReverseOrder_ReturnsBestMatchesFirst()
		{
			// Arrange

			var listOfKeywords = new[] { "Cat", "CatDog", "ActualCat", "DogCat1" };
			var expectedItems = listOfKeywords.Select( k => GetItemMock( k ) );
			
			foreach ( var item in expectedItems.Reverse() )
			{
				index.Add( item );
			}

			// Act
			var result = index.Search( "Cat" );

			// Assert
			var expected = expectedItems.Select( i => i.ToString() );
			var actual = result.Select( i => i.ToString() );
			CollectionAssert.AreEqual( expected, actual );
		}

		[TestCase( "O", "U" )]
		public void Search_UnknownItems_ReturnsEmptyResult( string query, params string[] keyword )
		{
			// Arrange
			var item1 = GetItemMock( keyword );
			index.Add( item1 );

			// Act
			var result = index.Search( query );

			// Assert
			Assert.That( result, Is.Empty );
		}

		private static IIndexableItem GetItemMock( params string[] keyword )
		{
			var item = new Mock<IIndexableItem>();
			item.Setup( m => m.GetKeywords() ).Returns( keyword );
			item.Setup( m => m.ToString() ).Returns( string.Join( ',', keyword ) );
			return item.Object;
		}
	}

	public class TestItem : IIndexableItem
	{
		private readonly string[] myKeywords;

		public TestItem( string[] keywords )
		{
			myKeywords = keywords;
		}

		public IEnumerable<string> GetKeywords()
		{
			return myKeywords;
		}
	}
}