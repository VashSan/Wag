using System.Diagnostics;
using System.Windows.Input;
using Wag.Interface;

namespace Wag.Domain
{
	public class StartMenuViewModel : ViewModelBase, IStartMenuViewModel
	{
		public StartMenuViewModel()
		{
			UpdateSourcesCommand = new RelayCommand( UpdateSources );
		}

		private string _query;

		public string Query
		{
			get => _query;
			set	
			{
				if ( value == _query )
					return;
				_query = value;
				OnPropertyChanged( nameof( Query ) );
			}
		}

		public ICommand UpdateSourcesCommand { get; }

		private void UpdateSources( object obj )
		{
			Debug.WriteLine( "Update" );
		}
	}

	
}
