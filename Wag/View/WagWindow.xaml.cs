using System.Windows;
using Wag.Interface;

namespace Wag.View
{
    /// <summary>
    /// Interaction logic for WagWindow.xaml
    /// </summary>
    public partial class WagWindow : Window
    {
        public WagWindow( IWagViewModel viewModel )
        {
	        DataContext = viewModel;

            InitializeComponent();
        }
    }
}
