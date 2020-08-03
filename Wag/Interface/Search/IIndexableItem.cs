using System.Collections.Generic;

namespace Wag.Interface.Search
{
	public interface IIndexableItem
	{
		IEnumerable<string> GetKeywords();
	}
}