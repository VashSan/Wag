using System;
using System.Collections.Generic;
using Wag.Interface.Search;

namespace Wag.Domain.Search
{
	public class Index<T> : IIndex<T> where T : IIndexableItem
	{
		public void Add( T item )
		{
			throw new NotImplementedException();
		}

		public void Remove( T item )
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> Search( string keyword )
		{
			throw new NotImplementedException();
		}
	}

}
