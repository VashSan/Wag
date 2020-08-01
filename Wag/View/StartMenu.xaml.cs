using System.Windows;
using Wag.Interface;

namespace Wag.View
{
    /// <summary>
    /// Interaction logic for WagWindow.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        public StartMenu( IStartMenuViewModel viewModel )
        {
	        DataContext = viewModel;

            InitializeComponent();
        }
    }
}
