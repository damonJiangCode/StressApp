using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyXamarinApp.ViewModels;
using Xamarin.Essentials;
using Firebase.Database;
using MyXamarinApp.Models;
using Newtonsoft.Json;

namespace MyXamarinApp.Views
{
    public partial class LogInPage : ContentPage
    {

        FirebaseClient firebaseClient;

        public LogInPage()
        {
            InitializeComponent();
        }

        // jump to main page
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            // connect DB
            firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

            // get data from DB
            var userList = await firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            // check whether credentials exist
            bool found = false;

            // check credentials
            foreach (var user in userList)
            {
                if (user.Object.UserName.Equals(userName.Text) && user.Object.Password.Equals(password.Text))
                {
                    // store the credentials to local device
                    var userInfo = JsonConvert.SerializeObject(user);
                    Application.Current.Properties.Add("account", userInfo);
                    Application.Current.SavePropertiesAsync();
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
