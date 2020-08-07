using System.Collections.Generic;
using Wag.Interface.Search;

namespace Wag.Domain.Search
{
	public class SearchController<T> : ISearchController<T> where T : IIndexableItem
	{
		private IIndex<T> Index { get; }

		private ISearchInquirer<T> Inquirer { get; set; }
		private IIndexSource<T> Source { get; set; }

		public SearchController() : this( new Index<T>() )
		{
		}

		internal SearchController( IIndex<T> index )
		{
			Index = index;
		}

		public void Register( ISearchInquirer<T> inquirer, string propertyName )
		{
			Inquirer = inquirer;
			inquirer.PropertyChanged += ( s, e ) =>
			{
				if ( e.PropertyName == nameof(inquirer.Query) )
				{
					var result = Index.Search( inquirer.Query );
					UpdateInquirer( result );
				}
			};
		}

		private void UpdateInquirer( IEnumerable<T> result )
		{
			// TODO can we avoid the clear?
			Inquirer.SearchResult.Clear();
			foreach ( var item in result )
			{
				Inquirer.SearchResult.Add( item );
			}
		}

		public void AddIndexSource( IIndexSource<T> indexSource )
		{
			if ( Source != null )
			{
				throw new System.NotSupportedException( "Only a single source is supported" );
			}

			Source = indexSource;
		}

		public void RefreshIndex()
		{
			foreach ( var item in Source.GetIndexableItems() )
			{
				Index.Add( item );
			}
		}
	}
}