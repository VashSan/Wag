using System.Collections.Generic;

namespace Wag.Interface.Search
{
	public interface IIndexSource<out T> where T : IIndexableItem
	{
		IEnumerable<T> GetIndexableItems();
	}
}
