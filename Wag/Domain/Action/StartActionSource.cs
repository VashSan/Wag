using System.Collections.Generic;
using System.Linq;
using Wag.Interface;
using Wag.Interface.Action;
using Wag.Interface.Search;

namespace Wag.Domain.Action
{
	public class StartActionSource : IIndexSource<IStartMenuAction>
	{
		private List<IStartActionProvider> Providers { get; } = new List<IStartActionProvider>();

		public IEnumerable<IStartMenuAction> GetIndexableItems()
		{
			return Providers.SelectMany( p => p.GetActions() );
		}

		public void Add( IStartActionProvider provider )
		{
			Providers.Add( provider );
		}
	}
}