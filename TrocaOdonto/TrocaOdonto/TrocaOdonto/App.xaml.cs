using System;
using TrocaOdonto.Services;
using TrocaOdonto.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrocaOdonto
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
