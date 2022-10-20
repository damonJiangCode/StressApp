using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyXamarinApp.ViewModels;
using Xamarin.Essentials;

namespace MyXamarinApp.Views
{
    public partial class LogInPage : ContentPage
    {
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
            if (UserName.Text == "Damon" && Password.Text == "1234")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alert", "User name or password is incorrect!", "ok");
            }
        }

        // jump to register page 
        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
