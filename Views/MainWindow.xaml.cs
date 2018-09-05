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
        public MainWindow()
        {
            this.SizeToContent = SizeToContent.Width;

            InitializeComponent();

            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var instWindow = new SetInstanceWindow();
            instWindow.ShowDialog();



        }


    }
}
