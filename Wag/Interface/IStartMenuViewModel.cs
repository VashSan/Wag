using System.ComponentModel;
using System.Windows.Input;

namespace Wag.Interface
{
	public interface IStartMenuViewModel : INotifyPropertyChanged
	{
		ICommand UpdateSourcesCommand { get; }
		public string Query { get; set; }
	}
}