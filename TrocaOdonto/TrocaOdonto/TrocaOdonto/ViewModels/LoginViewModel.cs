using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrocaOdonto.Views;
using Xamarin.Forms;

namespace TrocaOdonto.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }

        private string _UserPassword;

        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; OnPropertyChanged(); }
        }



        public LoginViewModel()
        {
            LoginCommand = new Command(LoginCommandAsync);
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async void LoginCommandAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Application.Current.MainPage.Navigation.PushAsync(new AppShell());
        }
        private async Task RegisterCommandAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Application.Current.MainPage.Navigation.PushAsync(new NewUserPage());
        }
    }
}
