using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Wag.Interface.Search
{
	public interface ISearchInquirer<T> : INotifyPropertyChanged where T : IIndexableItem
	{
		public string Query { get; }
		IList<T> SearchResult { get; }
	}
}
