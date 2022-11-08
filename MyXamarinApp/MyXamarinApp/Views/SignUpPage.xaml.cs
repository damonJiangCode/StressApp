using MyXamarinApp.ViewModels;
using MyXamarinApp.Models;
using Xamarin.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using Xamarin.Essentials;
using Firebase.Database.Query;

namespace MyXamarinApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        // connect the database
        FirebaseClient firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

        public SignUpPage()
        {
            // BindingContext = new SignUpViewModel(Navigation);
            InitializeComponent();
        }

        // jump to swipe card view page
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (RecordPassword.Text == RecordCheckPassword.Text)
            {
                firebaseClient.Child("Users").PostAsync(new User() {
                    UserName = RecordUserName.Text,
                    Email = RecordEmail.Text,
                    PhoneNumber = RecordPhoneNumber.Text,
                    Password = RecordPassword.Text
                });
                await DisplayAlert("Success", "Registered successfully", "OK");
                await Navigation.PushAsync(new QuestionPage());
            } else
            {
                await DisplayAlert("Alert", "The password you typed does not match.", "OK");
            }
        }
    }
}
