using System;
using System.Collections.Generic;
using System.Text;

namespace TrocaOdonto.Models
{
    public class RecoveryPassword
    {
        private string _NewPassword;
        public string NewPassword
        {
            get => _NewPassword;
            set { _NewPassword = value; }
        }
        private string _NewPasswordVerification;
        public string NewPasswordVerification
        {
            get => _NewPasswordVerification;
            set { _NewPasswordVerification = value; }
        }
    }
}
