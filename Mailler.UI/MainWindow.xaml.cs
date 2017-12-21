using Mailler.DataAccess;
using Mailler.UI.ViewModel;
using System.Windows;

namespace Mailler.UI
{
    
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitPaths p = new InitPaths();
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            _viewModel.Load();            
        }
    }
}
