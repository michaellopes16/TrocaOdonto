using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrocaOdonto.Models;
using TrocaOdonto.Views;
using TrocaOdonto.Views.UserControls;
using Xamarin.Forms;

namespace TrocaOdonto.ViewModels
{
    public class ForgotPasswordModelView3: BaseViewModel
    {
        public Command SavePasswordCommand { get; }
        private bool _CanDoAction;
        public bool CanDoAction
        {
            get => _CanDoAction;
            set { _CanDoAction = value; OnPropertyChanged(); }
        }

        private string _NewPassword;
        public string NewPassword
        {
            get => _NewPassword;
            set { _NewPassword = value; OnPropertyChanged(); }
        }
        private string _NewPasswordVerification;
        public string NewPasswordVerification
        {
            get => _NewPasswordVerification;
            set { _NewPasswordVerification = value; OnPropertyChanged(); }
        }
        public ForgotPasswordModelView3()
        {
            CanDoAction = true;
            SavePasswordCommand = new Command<RecoveryPassword>(async (x) => await ConfirmCodeVerification(x));
        }

        private async Task ConfirmCodeVerification(object sender)
        {

            var recoveryPassword = sender as RecoveryPassword;
            CanDoAction = false;
            await Task.Delay(500);
            if (recoveryPassword != null)
            {
                NewPassword = recoveryPassword.NewPassword;
                NewPasswordVerification = recoveryPassword.NewPasswordVerification;
            }
            if (CheckSamePassword(NewPassword, NewPasswordVerification) == 1)
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Deu certo!", "Agora é só tentar fazer Login novamente :)"));
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else if (CheckSamePassword(NewPassword, NewPasswordVerification) == -1)
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro!", "Campo Vazio. Tem que ter uma senha pra salvar né? Se liga ai heheh!"));
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro!", "Tem que ser a mesma senha, blz? Presta atenção ai heheh !"));
            }
            CanDoAction = true;
        }

        private int CheckSamePassword(string NewPassword, string PassowordVerification)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(NewPassword) && !string.IsNullOrEmpty(PassowordVerification))
            {
                if (NewPassword.ToLower().Equals(PassowordVerification.ToLower()))
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

