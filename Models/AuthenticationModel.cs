using Newtonsoft.Json;
using NLog;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TootNet;

namespace TootDon.Models
{
    class AuthenticationModel : BindableBase, INotifyPropertyChanged
    {


        // 認証コード
        public string _authCode;
        public string AuthCode
        {
            get => _authCode;
            set => SetProperty(ref _authCode, value);
        }

        // インスタンスネーム
        public string _instanceName;
        public String InstanceName
        {
            get => _instanceName;
            set => SetProperty(ref _instanceName, value);
        }

        // Tokens
        public Tokens _tokens;
        public Tokens Tokens
        {
            get => _tokens;
            set => SetProperty(ref _tokens, value);

        }

        public AuthenticationModel()
        {

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
