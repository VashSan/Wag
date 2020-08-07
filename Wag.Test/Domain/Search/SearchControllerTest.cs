using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Moq;
using NUnit.Framework;
using Wag.Domain.Search;
using Wag.Interface;
using Wag.Interface.Action;
using Wag.Interface.Search;

namespace Wag.Test.Domain.Search
{
	class SearchControllerTest
	{
		[Test]
		public void Query_Change_UpdatesResults()
		{
			// Arrange
			var index = new Mock<IIndex<IStartMenuAction>>();
			index.Setup( i => i.Search( It.IsAny<string>() ) ).Returns( CreateResultList() );

			var actionList = new ObservableCollection<IStartMenuAction>();
			var inquirer = CreateInquirer( actionList );

			var searchController = new SearchController<IStartMenuAction>( index.Object );
			searchController.Register( inquirer.Object, nameof( inquirer.Object.Query ) );

			// Act
			inquirer.Raise( m => m.PropertyChanged += null, new PropertyChangedEventArgs( nameof( inquirer.Object.Query ) ) );

			// Assert
			Assert.That( actionList.Count, Is.GreaterThan( 0 ) );
		}

		private static List<IStartMenuAction> CreateResultList()
		{
			var resultList = new List<IStartMenuAction>();
			resultList.Add( Mock.Of<IStartMenuAction>() );
			return resultList;
		}

		private static Mock<ISearchInquirer<IStartMenuAction>> CreateInquirer(
			IList<IStartMenuAction> actionList )
		{
			var inquirer = new Mock<ISearchInquirer<IStartMenuAction>>();
			inquirer.Setup( m => m.Query ).Returns( "something" );

			inquirer.Setup( m => m.SearchResult ).Returns( actionList );
			return inquirer;
		}

		[Test]
		public void Update_Invocation_InvokesIndexSource()
		{
			// Arrange
			var mock = new Mock<IIndexSource<IStartMenuAction>>();
			var searchController = new SearchController<IStartMenuAction>();
			searchController.AddIndexSource( mock.Object );

			// Act
			searchController.RefreshIndex();

			// Assert
			mock.Verify( m => m.GetIndexableItems(), Times.Once );
		}
	}
}
