using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wag.View;
using Wag.Domain;

namespace Wag
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			var viewmodel = new StartMenuViewModel();
			var view = new StartMenu( viewmodel );
			view.Show();
		}
	}
}
