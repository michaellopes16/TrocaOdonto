using System;
using System.Collections.Generic;
using System.Text;

namespace TrocaOdonto.ViewModels
{
    public class NewUserViewModel:BaseViewModel
    {
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

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(); }
        }

        private string _DateOfBirth;

        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; OnPropertyChanged(); }
        }

        private string _IsFicalPeople;

        public string IsFicalPeople
        {
            get { return _IsFicalPeople; }
            set { _IsFicalPeople = value; OnPropertyChanged(); }
        }

        private string _UniqueIdentification;

        public string UniqueIdentification
        {
            get { return _UniqueIdentification; }
            set { _UniqueIdentification = value; OnPropertyChanged(); }
        }

        private string _CEP;

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; OnPropertyChanged(); }
        }
    }
}
