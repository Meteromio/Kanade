using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TootDon.Models;

namespace TootDon.ViewModels
{
    public class SetInstanceViewModel : BindableBase
    {
        MainWindowModal Model = MainWindowModal.Instance;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DelegateCommand URLButtonClicked { get; private set; }

        public AsyncReactiveCommand AuthCodeButtonClicked { get; } = new AsyncReactiveCommand();

        // Viewへのリクエスト
        public EventAggregator Messenger { get; } = new EventAggregator();

        public SetInstanceViewModel()
        {

            URLButtonClicked = new DelegateCommand(
                async () =>
                {
                    try
                    {
                        // 処理書く
                        var redirectURL = await Task.Run(() => Model.GetAuthorizeUrl());
                        Process.Start(redirectURL);

                    }
                    catch (UriFormatException ax)
                    {
                        logger.Error(ax.Message);
                    }
                },
                // 認証コード入力欄表示可能か？？？
                () => true);



            AuthCodeButtonClicked.Subscribe(
                async () =>
                {
                    try
                    {
                        var result = await Task.Run(() => Model.AuthorizeWithCode());
                        if (result)
                        {

                            var verify = await Model.Tokens.Accounts.VerifyCredentialsAsync();
                            Messenger.GetEvent<PubSubEvent>().Publish();

                        }
                        else
                        {
                            logger.Error("Error : Tokens取得失敗");
                        }

                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex);
                    }

                });
        }


        
        // 認証コード
        public string code
        {
            get => Model._authCode;
            set => SetProperty(ref Model._authCode, value);
            
        }

        // インスタンス名
        public string InstanceName
        {
            get => Model._instanceName;
            set => SetProperty(ref Model._instanceName, value);
        }



    }
}
