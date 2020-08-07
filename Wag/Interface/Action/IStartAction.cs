using Wag.Interface.Search;

namespace Wag.Interface.Action
{
	public interface IStartMenuAction : IIndexableItem
	{
		string Executable { get; }
	}
}
