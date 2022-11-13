using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyXamarinApp.ViewModels;
using Xamarin.Essentials;
using Firebase.Database;

namespace MyXamarinApp.Views
{
    public partial class LogInPage : ContentPage
    {
        // connect the database
        FirebaseClient firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

        public LogInPage()
        {

            //var vm = new LogInViewModel();
            //this.BindingContext = vm;
            //vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();
        }

        // jump to main page
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var userList = await firebaseClient.Child("Users").OnceAsync<Models.User>();

            bool found = false;

            foreach (var user in userList)
            {
                if (user.Object.UserName.Equals(UserName.Text) && user.Object.Password.Equals(Password.Text))
                {
                    found = true;
                    await Navigation.PushAsync(new MainPage());
                }
            }
            if (!found)
            DisplayAlert("Alert", "User name or password is incorrect!", "ok");

           
        }

        // jump to register page 
        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
