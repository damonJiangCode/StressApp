using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyXamarinApp.ViewModels;

namespace MyXamarinApp.Views
{	
	public partial class ProfilePage : ContentPage
    { 
        private ProfileViewModel viewModel;

        public ProfilePage()
        {
            InitializeComponent();
            viewModel = new ProfileViewModel();
            BindingContext = viewModel;
            birthDatePicker.Date = DateTime.Today;
            birthDatePicker.MaximumDate = DateTime.Today;
        }
	}
}

