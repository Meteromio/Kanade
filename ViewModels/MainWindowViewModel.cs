using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TootDon.Models;
using TootNet;

namespace TootDon.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        MainWindowModal Model = MainWindowModal.Instance;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public DelegateCommand TootButtonClicked { get; private set; }
        public MainWindowViewModel()
        {
            TootButtonClicked = new DelegateCommand(
                async () =>
                {
                    try
                    {

                       var TootResult =  await Tokens.Statuses.PostAsync(status => _tootText, visibity => "private");
                       
                    }
                    catch (Exception ax)
                    {
                        logger.Error(ax);
                        
                    }
                    finally
                    {
                        
                    }

                });
        }


        // toot公開範囲
        public string _visibity;
        public string Visibity
        {
            get => Model._visibity;
            set => SetProperty(ref Model._visibity, value);
        }

        // toot内容
        public string _tootText;
        public string TootText
        {
            get => _tootText;
            set => SetProperty(ref _tootText ,value);
        }
        public Tokens _tokens;
        public Tokens Tokens
        {
            get => Model._tokens;
            
        }
    }
}
