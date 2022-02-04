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
    public partial class TrocaOdontoTextBoxEntry : ContentView
    {

        private string _FieldText;

        public string FieldText
        {
            get { return _FieldText; }
            set { _FieldText = value; }
        }
        private string _IconResource;

        public string IconResource
        {
            get { return _IconResource; }
            set { _IconResource = value; }
        }

        public TrocaOdontoTextBoxEntry()
        {
            InitializeComponent();
        }

    }
}