using System.Collections.Generic;

namespace Wag.Interface.Search
{
	public interface IIndex<T> where T : IIndexableItem
	{
		void Add( T item );
		void Clear();
		IEnumerable<T> Search( string query );
	}
}