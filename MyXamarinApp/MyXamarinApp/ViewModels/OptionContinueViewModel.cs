using System;
using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using MyXamarinApp.Views;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyXamarinApp.ViewModels
{
    public class OptionContinueViewModel : BaseViewModel
    {
        private readonly INavigation Navigation;

        public OptionContinueViewModel(INavigation navigation)
        {
            SignUpCommand = new Command(async () => await OnSignUpCommandAsync());
            GuestCommand = new Command(async () => await OnGuestCommandAsync());
        }

        public Command SignUpCommand { get;}
        public Command GuestCommand { get;}

        async Task OnSignUpCommandAsync()
        {
            await Navigation.PushAsync(new SignUpPage(), true);
        }

        async Task OnGuestCommandAsync()
        {
            await Navigation.PushAsync(new LogInPage(), true);
        }
    }
}

