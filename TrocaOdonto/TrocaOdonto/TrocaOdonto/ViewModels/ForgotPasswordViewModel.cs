using System.Threading.Tasks;
using TrocaOdonto.Util;
using Xamarin.Forms;
using TrocaOdonto.Views;
using TrocaOdonto.Views.UserControls;
using Rg.Plugins.Popup.Extensions;
using Android.Content.Res;

namespace TrocaOdonto.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        public Command SendEmailForgotPassword { get; }
        private bool _CanDoAction;
        public bool CanDoAction
        {
            get => _CanDoAction;
            set { _CanDoAction = value; OnPropertyChanged(); }
        }

        private string _EmailToRecover;
        public string EmailToRecover
        {
            get => _EmailToRecover;
            set { _EmailToRecover = value; OnPropertyChanged(); }
        }
        public ForgotPasswordViewModel()
        {
            CanDoAction = true;
            SendEmailForgotPassword = new Command<TrocaOdontoTextBoxEntry>(async (x) => await SendEmailForgotPasswordCommandAsync(x));
        }

        private async Task SendEmailForgotPasswordCommandAsync(object sender)
        {
            var entry = sender as TrocaOdontoTextBoxEntry;
            CanDoAction = false;
            await Task.Delay(500);
            SendMail sendMail = new SendMail();
            EmailToRecover = entry.TextField;
            string mail = EmailToRecover;// "mlb@cin.ufpe.br"
            string user = "Michael Lopes";// Buscar por nome do usuário na base
            if (CheckIfEmailExist(mail) == 1)
            {
                if (sendMail.SendForgotMailToUser(mail, user))
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage2());
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro", "Não conseguimos enviar seu email de recuperação. Tente mais tarde com outro email!"));
                }
            }else if (CheckIfEmailExist(mail) == -1) {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro", "Campo Vazio. Insira um email válido!"));
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(new TrocaOdontoDialog("Erro", "Email não existe na base. Cadastre-se!"));              
            }
            CanDoAction = true;
        }

        private int CheckIfEmailExist(string email)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(email))
            {
                if (email.ToLower().Equals("mlb@cin.ufpe.br"))
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

