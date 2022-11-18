using System;
using System.Windows.Input;
using Xamarin.Forms;
using MyXamarinApp.Views;

namespace MyXamarinApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        String _textDisplay;
        private readonly INavigation Navigation;
        bool _buttonDisplay;

        public SettingsViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            // check whether it is logged in
            if (Application.Current.Properties.ContainsKey("account"))
            {
                _textDisplay = "Sign out";
                _buttonDisplay = true;
            }
            else
            {
                _textDisplay = "Log in";
                _buttonDisplay = false;
            }

            LoginOrSignoutCommand = new Command(OnLoginOrSignOutCommand);

            ClickCommand = new Command(OnClickCommand);
        }


        public String textDisplay
        {
            get => _textDisplay;
            set
            {
                _textDisplay = value;
                RaisePropertyChanged();
            }
        }


        public bool ButtonDisplay
        {
            get => _buttonDisplay;
            set
            {
                _buttonDisplay = value;
                RaisePropertyChanged();
            }
        }


        public Command LoginOrSignoutCommand { get; }

        public async void OnLoginOrSignOutCommand(object obj)
        {
            if (_textDisplay.Equals("Log in"))
            {
                await Navigation.PushAsync(new LogInPage());

            } else if (_textDisplay.Equals("Sign out"))
            {
                bool answer = await Application.Current.MainPage.DisplayAlert("Notice", "Do you want to sign out?", "Yes", "No");
                if (answer)
                {
                    Application.Current.Properties.Remove("account");
                    await Navigation.PushAsync(new MainPage());
                } 
            }
        }


        public Command ClickCommand { get; }

        public async void OnClickCommand(object obj)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}


