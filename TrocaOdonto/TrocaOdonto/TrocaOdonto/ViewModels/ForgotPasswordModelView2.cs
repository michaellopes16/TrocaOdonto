using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrocaOdonto.Util;
using TrocaOdonto.Views;
using TrocaOdonto.Views.UserControls;
using Xamarin.Forms;

namespace TrocaOdonto.ViewModels
{
    public class ForgotPasswordModelView2 : BaseViewModel
    {
        public Command VerifyCodeCommand { get; }
        private bool _CanDoAction;
        public bool CanDoAction
        {
            get => _CanDoAction;
            set { _CanDoAction = value; OnPropertyChanged(); }
        }

        private string _CodeVerification;
        public string CodeVerification
        {
            get => _CodeVerification;
            set { _CodeVerification = value; OnPropertyChanged(); }
        }
        public ForgotPasswordModelView2()
        {
            CanDoAction = true;
            VerifyCodeCommand = new Command<TrocaOdontoTextBoxEntry>(async (x) => await ConfirmCodeVerification(x));
        }

        private async Task ConfirmCodeVerification(object sender)
        {
            var entry = sender as TrocaOdontoTextBoxEntry;
            CanDoAction = false;
            await Task.Delay(500);
            CodeVerification = entry.TextField;
            if (CheckCode(CodeVerification) == 1)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ForgotoPasswordPage3());
            }
            else if (CheckCode(CodeVerification) == -1)
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro!", "Campo Vazio. Insira um código válido!"));
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro!", "Teu código tá errado visse? Presta atenção ai no email!"));
            }
            CanDoAction = true;
        }

        private int CheckCode(string code)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(code))
            {
                if (code.ToLower().Equals(SendMail.VALIDATION_COD.ToLower()))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
