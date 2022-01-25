using System;
using System.Collections.Generic;
using System.ComponentModel;
using TrocaOdonto.Models;
using TrocaOdonto.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrocaOdonto.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}