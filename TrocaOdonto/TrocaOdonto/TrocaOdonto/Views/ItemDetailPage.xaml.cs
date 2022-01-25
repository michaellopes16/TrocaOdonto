using System.ComponentModel;
using TrocaOdonto.ViewModels;
using Xamarin.Forms;

namespace TrocaOdonto.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}