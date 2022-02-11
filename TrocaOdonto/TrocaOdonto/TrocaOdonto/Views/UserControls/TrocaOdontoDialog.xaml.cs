using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrocaOdonto.Views.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrocaOdontoDialog : Rg.Plugins.Popup.Pages.PopupPage
    {
        public TrocaOdontoDialog(string title, string description)
        {
            InitializeComponent();
            LabelTitle.Text = title;
            LabelDescription.Text = description;
        }

        private void PopupPage_BackgroundClicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}