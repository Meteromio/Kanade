using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TootNet;

namespace TootDon.Models
{
    class MainWindowModal: BindableBase
    {
        private static MainWindowModal MWInstance;
        public static MainWindowModal Instance
        {

            get
            {

                if (MWInstance == null)
                {
                    MWInstance = new MainWindowModal();
                }

                return MWInstance;
            }
        }

        // 認証コード
        public string _authCode;
        public string AuthCode
        {
            get => _authCode;
            set => SetProperty(ref _authCode, value);
        }
      
        public Tokens _tokens;
        public Tokens Tokens
        {
            get => _tokens;
            set => SetProperty(ref _tokens,value);
        }

        // toot公開範囲
        public string _visibity;
        public string Visibity
        {
            get => _visibity;
            set => SetProperty(ref _visibity, value);
        }

        // toot内容
        public string _tootText;
        public string TootText
        {
            get => _tootText;
            set => SetProperty(ref _tootText, value);
        }
        // インスタンスネーム
        public string _instanceName;
        public String InstanceName
        {
            get => _instanceName;
            set => SetProperty(ref _instanceName, value);
        }

        // 認証用のURLを取得する
        public Authorize authorize { get; set; }
        public async Task<String> GetAuthorizeUrl()
        {
            authorize = new Authorize();
            string authorizeUrl = "";
            await authorize.CreateApp(_instanceName, "Kanade for Mastodon", Scope.Read | Scope.Write, "");
            authorizeUrl = authorize.GetAuthorizeUri();

            return authorizeUrl;
        }

        // 認証処理
        private Tokens tokens { get; set; }
        public async Task<bool> AuthorizeWithCode()
        {

            var tokens = await authorize.AuthorizeWithCode(_authCode);
            // modelに保存(メインViewのモデルに輸送したい)
            Tokens = tokens;
            return tokens != null;
        }
    }
}
