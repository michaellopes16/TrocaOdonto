using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TrocaOdonto.Views;
using Xamarin.Essentials;

namespace TrocaOdonto.ViewModels
{
    public class NewUserViewModel:BaseViewModel
    {
        private string _UserName;
        public Command RegisterUserCommand { get; }
        public Command LoadImageUserCommand { get; }

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

        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; OnPropertyChanged(); }
        }

        private string _DateOfBirth;

        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; OnPropertyChanged(); }
        }

        private bool _IsFicalPerson;

        public bool IsFicalPerson
        {
            get => _IsFicalPerson;
            set { _IsFicalPerson = value; OnPropertyChanged(); }
        }

        private string _UniqueIdentification;

        public string UniqueIdentification
        {
            get { return _UniqueIdentification; }
            set { _UniqueIdentification = value; OnPropertyChanged(); }
        }

        public NewUserViewModel()
        {
            RegisterUserCommand = new Command(async () => await RegisterCommandAsync());
            LoadImageUserCommand = new Command<Image>(async (x) => await LoadImageUserCommandAsync(x));
        }

        private async Task LoadImageUserCommandAsync(Image image)
        {
            try
            {
                var file = await FilePicker.PickAsync(
                    new PickOptions
                    {
                        PickerTitle = "Por favor, escolha uma foto para seu perfil",
                        FileTypes = FilePickerFileType.Images
                    });

                if (file != null)
                {
                    var stream = await file.OpenReadAsync();
                    image.Source = ImageSource.FromStream(() => stream);
                    // Get peth of image here in future
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Problema ao carregar a imagem", "OK");
            }
        }

        private async Task RegisterCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ItemsPage());
        }
    }
}
