using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Wag.Domain.Search;
using Wag.Interface;
using Wag.Interface.Search;

namespace Wag.Domain
{
	public class StartMenuViewModel : ViewModelBase, IStartMenuViewModel
	{
		private ISearchController Search { get; }

		public StartMenuViewModel() : this( new SearchController() )
		{

		}

		public StartMenuViewModel( ISearchController searchController )
		{
			Search = searchController;
			Search.Register( this, nameof( Query ) );
			UpdateSourcesCommand = new RelayCommand( UpdateSources );
		}

		private string myQuery;

		public string Query
		{
			get => myQuery;
			set
			{
				if ( value == myQuery )
					return;
				myQuery = value;
				OnPropertyChanged( nameof( Query ) );
			}
		}

		public ObservableCollection<IStartMenuAction> Actions { get; } = new ObservableCollection<IStartMenuAction>();

		public ICommand UpdateSourcesCommand { get; }

		private void UpdateSources( object obj )
		{
			// TODO recreate Index> Notify Search controller
			Debug.WriteLine( "Update" );
		}
	}


}
