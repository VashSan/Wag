using System.Collections.Generic;

namespace Wag.Interface.Search
{
	public interface IIndex<T> where T : IIndexableItem
	{
		void Add( T item );
		void Remove( T item );
		IEnumerable<T> Search( string keyword );
	}
}