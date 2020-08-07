using System.ComponentModel;

namespace Wag.Interface.Search
{
	public interface ISearchController<T> where T : IIndexableItem
	{
		void Register( ISearchInquirer<T> sourceObject, string propertyName );
		void AddIndexSource( IIndexSource<T> indexSource );
		void RefreshIndex();
	}
}
