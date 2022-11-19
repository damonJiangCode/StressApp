using MyXamarinApp.ViewModels;
using MyXamarinApp.Models;
using Xamarin.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;


namespace MyXamarinApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new SignUpViewModel(Navigation);
        }
    }
}
