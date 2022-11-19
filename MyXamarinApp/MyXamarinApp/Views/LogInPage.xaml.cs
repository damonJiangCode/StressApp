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
        public LogInPage()
        {
            InitializeComponent();
            BindingContext = new LogInViewModel(Navigation);
        }
    }
}
