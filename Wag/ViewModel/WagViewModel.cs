﻿using System.Diagnostics;
using System.Windows.Input;
using Wag.Interface;

namespace Wag.ViewModel
{
	public class WagViewModel : ViewModelBase, IWagViewModel
	{
		public WagViewModel()
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
