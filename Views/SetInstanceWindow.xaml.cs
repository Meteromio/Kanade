using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
