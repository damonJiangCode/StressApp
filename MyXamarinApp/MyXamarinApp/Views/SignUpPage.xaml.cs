using System;
using System.Collections.Generic;
using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            BindingContext = new SignUpViewModel();
            InitializeComponent();
        }
    }
}

