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
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(TextField),
                                typeof(string),
                                typeof(TrocaOdontoTextBoxEntry),
                                defaultValue: string.Empty,
                                defaultBindingMode:BindingMode.OneWay,
                                propertyChanged: PlaceholderPropertyChanged);

        private static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var trocaOdontoTextBox = (TrocaOdontoTextBoxEntry)bindable;
            trocaOdontoTextBox.TextFieldName.Placeholder = newValue?.ToString();
        }

        public string Placeholder
        {
            get { return base.GetValue(PlaceholderProperty)?.ToString(); }
            set { base.SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword),
                        typeof(bool),
                        typeof(TrocaOdontoTextBoxEntry),
                        defaultValue: false,
                        defaultBindingMode: BindingMode.OneWay,
                        propertyChanged: IsPasswordPropertyChanged);

        private static void IsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var trocaOdontoTextBox = (TrocaOdontoTextBoxEntry)bindable;
            trocaOdontoTextBox.TextFieldName.IsPassword = (bool) newValue;
        }

        public bool IsPassword
        {
            get { return (bool) base.GetValue(IsPasswordProperty); }
            set { base.SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty TextFieldProperty = BindableProperty.Create(nameof(TextField),
                        typeof(string),
                        typeof(TrocaOdontoTextBoxEntry),
                        defaultValue: string.Empty,
                        defaultBindingMode: BindingMode.OneWay,
                        propertyChanged: TextFieldPropertyChanged);

        private static void TextFieldPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var trocaOdontoTextBox = (TrocaOdontoTextBoxEntry)bindable;
            trocaOdontoTextBox.TextFieldName.Text = newValue?.ToString();
        }

        public string TextField
        {
            get { return base.GetValue(TextFieldProperty)?.ToString(); }
            set { base.SetValue(TextFieldProperty, value); }
        }

        public static readonly BindableProperty SourceImageFieldProperty = BindableProperty.Create(nameof(SourceImageField),
                                        typeof(string),
                                        typeof(TrocaOdontoTextBoxEntry),
                                        defaultValue: string.Empty,
                                        defaultBindingMode: BindingMode.OneWay,
                                        propertyChanged: SourceImageFieldPropertyChanged);

        private static void SourceImageFieldPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var trocaOdontoTextBox = (TrocaOdontoTextBoxEntry)bindable;
            trocaOdontoTextBox.ImageIcon.Source = newValue?.ToString();
        }

        public string SourceImageField
        {
            get { return base.GetValue(SourceImageFieldProperty)?.ToString(); }
            set { base.SetValue(SourceImageFieldProperty, value); }
        }

        public TrocaOdontoTextBoxEntry()
        {
            InitializeComponent();
        }

    }
}