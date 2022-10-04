﻿using System;
using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using MyXamarinApp.Views;
using System.Threading.Tasks;

namespace MyXamarinApp.ViewModels
{
    public class OptionContinueViewModel : BaseViewModel
    {
        private readonly INavigation Navigation;

        public OptionContinueViewModel()
        {
            GoToSignUpCommand = new Command(async () => await OnSignUpCommandAsync());
            GoToGuestCommand = new Command(async () => await OnGuestCommandAsync());
        }

        public Command GoToSignUpCommand { get; }
        public Command GoToGuestCommand { get; }

        async Task OnSignUpCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
            //await Navigation.PushAsync(new SignUpPage(), true);
        }

        async Task OnGuestCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LogInPage());
            //await Navigation.PushAsync(new LogInPage(), true);
        }
    }
}

