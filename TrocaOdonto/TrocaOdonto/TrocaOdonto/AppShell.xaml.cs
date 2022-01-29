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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
