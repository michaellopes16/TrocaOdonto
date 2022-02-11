using System;
using System.Collections.Generic;
using System.Text;

namespace TrocaOdonto.ViewModels
{
    public class TrocaOdontoPopupViewModel : BaseViewModel
    {
        private string _TextLabelDescription;
        public string TextLabelDescription
        {
            get => _TextLabelDescription;
            set { _TextLabelDescription = value; OnPropertyChanged(); }
        }

        private string _TextLabelTitle;
        public string TextLabelTitle
        {
            get => _TextLabelTitle;
            set { _TextLabelTitle = value; OnPropertyChanged(); }
        }

        public TrocaOdontoPopupViewModel() {
            
            //TextLabelDescription = description;
            //TextLabelTitle = title;
        }
    }
}
