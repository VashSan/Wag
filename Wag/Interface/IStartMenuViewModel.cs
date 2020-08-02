using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Wag.Interface
{
	public interface IStartMenuAction
	{

	}

	public interface IStartMenuViewModel : INotifyPropertyChanged
	{
		ICommand UpdateSourcesCommand { get; }
		string Query { get; set; }
		ObservableCollection<IStartMenuAction> Actions { get; }
	}
}