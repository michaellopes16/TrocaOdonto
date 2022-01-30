using System;
using System.Collections.Generic;
using TrocaOdonto.ViewModels;
using TrocaOdonto.Views;
using Xamarin.Forms;

namespace TrocaOdonto
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        }

    }
}
