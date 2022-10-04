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
            var vm = new LogInViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();
        }
    }
}
