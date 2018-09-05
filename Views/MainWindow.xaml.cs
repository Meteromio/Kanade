using Prism.Events;
using System.Windows;
using TootDon.ViewModels;

namespace TootDon.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow()
        {
            this.SizeToContent = SizeToContent.Width;

            InitializeComponent();

            
            DataContext = viewModel;
            
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            var instWindow = new SetInstanceWindow();
            instWindow.ShowDialog();
            this.Visibility = Visibility.Visible;
            
            viewModel.AuthButonIsEnabled = false;

        }


    }
}
