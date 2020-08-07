using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Wag.Interface.Action;

namespace Wag.Interface
{
	public interface IStartMenuViewModel : INotifyPropertyChanged
	{
		ICommand UpdateSourcesCommand { get; }
		string Query { get; set; }
		ObservableCollection<IStartMenuAction> Actions { get; }
	}
}