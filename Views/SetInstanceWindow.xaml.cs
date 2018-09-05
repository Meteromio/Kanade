using Prism.Events;
using System.Windows;
using TootDon.ViewModels;

namespace TootDon.Views
{
    /// <summary>
    /// SetInstanceWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SetInstanceWindow : Window
    {
        public SetInstanceWindow()
        {
            InitializeComponent();
            var viewModel =new SetInstanceViewModel();
            DataContext = viewModel;
            viewModel.Messenger.GetEvent<PubSubEvent>().Subscribe(() => this.Close(), true);
        }
    }
}
