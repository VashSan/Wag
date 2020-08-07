using System.Collections.Generic;

namespace Wag.Interface.Action
{
	public interface IStartActionProvider
	{
		IEnumerable<IStartMenuAction> GetActions();
	}
}
