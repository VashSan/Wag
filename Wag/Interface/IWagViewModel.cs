using System.ComponentModel;
using System.Windows.Input;

namespace Wag.Interface
{
	public interface IWagViewModel : INotifyPropertyChanged
	{
		ICommand UpdateSourcesCommand { get; }
		public string Query { get; set; }
	}
}