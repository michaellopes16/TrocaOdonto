﻿using System;
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
        public Command ForgotPasswordCommand { get; }

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
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
            ForgotPasswordCommand = new Command(async () => await ForgotPasswordCommandAsync());
        }

        private async Task LoginCommandAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (IsUserExists(UserName) && IsPasswordCorrect(UserPassword))
            {
                //Application.Current.MainPage = new AppShell();
                await Shell.Current.Navigation.PushAsync(new AppShell());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Senha ou usuário inválidos!", "Ok");
            }
        }
        private async Task RegisterCommandAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Application.Current.MainPage.Navigation.PushAsync(new NewUserPage());
        }
        private async Task ForgotPasswordCommandAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());
        }

        private bool IsUserExists(string login)
        {
            return true;
        }

        private bool IsPasswordCorrect(string password)
        {
            return true;
        }
    }
}
