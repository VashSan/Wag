using System.Collections.Generic;
using System.Linq;
using Wag.Interface.Search;

namespace Wag.Domain.Search
{

	public class Index<T> : IIndex<T> where T : IIndexableItem
	{
		private readonly SortedIndex<T> myIndex = new SortedIndex<T>();

		public void Add( T item )
		{
			foreach ( string keyword in item.GetKeywords() )
			{
				string lowerCaseKeyword = keyword.ToLower();
				AddKeyword( lowerCaseKeyword );
				Relate( lowerCaseKeyword, item );
			}
		}

		private void AddKeyword( string keyword )
		{
			if ( !myIndex.ContainsKey( keyword ) )
			{
				myIndex.Add( keyword, new List<T>() );
			}
		}

		private void Relate( string keyword, T item )
		{
			var bucket = myIndex[ keyword ];
			if ( !bucket.Contains( item ) )
			{
				bucket.Add( item );
			}
		}

		public void Clear()
		{
			myIndex.Clear();
		}

		public IEnumerable<T> Search( string query )
		{
			var lowerQuery = query.ToLower();

			return SearchExactMatch( lowerQuery )
				.Union( SearchStartingWith( lowerQuery ) )
				.Union( SearchContains( lowerQuery ) );
		}

		private IEnumerable<T> SearchContains( string partialKeyword )
		{
			return myIndex.Keys
				.Where( key => key.Contains( partialKeyword ) )
				.SelectMany( key => myIndex[ key ] );
		}

		private IEnumerable<T> SearchStartingWith( string partialKeyword )
		{
			return myIndex.Keys
				.Where( key => key.StartsWith( partialKeyword ) )
				.SelectMany( key => myIndex[ key ] );
		}

		private IEnumerable<T> SearchExactMatch( string keyword )
		{
			return myIndex.Keys
				.Where( key => key.Equals( keyword ) )
				.SelectMany( key => myIndex[ key ] );
		}

		internal IEnumerable<T> GetAllIndexedItems()
		{
			return myIndex.Values.SelectMany( bucket => bucket );
		}

		private class SortedIndex<TValue> : SortedDictionary<string, List<TValue>>
		{
		}
	}
}