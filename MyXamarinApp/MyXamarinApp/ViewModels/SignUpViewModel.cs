using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using MyXamarinApp.Views;

namespace MyXamarinApp.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private readonly INavigation Navigation;
        readonly FirebaseClient firebaseClient;
        String _UserText;
        String _EmailText;
        String _PasswordText;
        String _ConfirmPasswordText;

        public SignUpViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

            _UserText = string.Empty;
            _EmailText = string.Empty;
            _PasswordText = string.Empty;
            _ConfirmPasswordText = string.Empty;

            SignupCommand = new Command(OnSignupCommand);
        }

        public String UserText
        {
            get => _UserText;
            set
            {
                _UserText = value;
                RaisePropertyChanged();
            }
        }

        public String EmailText
        {
            get => _EmailText;
            set
            {
                _EmailText = value;
                RaisePropertyChanged();
            }
        }

        public String PasswordText
        {
            get => _PasswordText;
            set
            {
                _PasswordText = value;
                RaisePropertyChanged();
            }
        }

        public String ConfirmPasswordText
        {
            get => _PasswordText;
            set
            {
                _ConfirmPasswordText = value;
                RaisePropertyChanged();
            }
        }

        public Command SignupCommand { get; }

        public async void OnSignupCommand()
        {

            // check valid inputs
            if (String.IsNullOrEmpty(_UserText))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "You did not type your user name!", "OK");
            }
            else if (String.IsNullOrEmpty(_EmailText))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "You did not type your email!", "OK");
            }
            else if (String.IsNullOrEmpty(_PasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "You did not type your password!", "OK");
            }
            else if (String.IsNullOrEmpty(_ConfirmPasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please type your password again!", "OK");
            }
            else if (!_ConfirmPasswordText.Equals(_PasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "The password you typed does not match.", "OK");
            }

            // valid inputs
            else
            {
                // a flag
                bool found = false;

                // get data from DB
                var users = await firebaseClient
                    .Child("Users")
                    .OnceAsync<Models.User>();

                // check whether the user name has been used
                foreach (var user in users)
                {
                    if (user.Object.UserName.Equals(_UserText))
                    {
                        found = true;
                        await Application.Current.MainPage.DisplayAlert("Alert", "User name has been used, please try again!", "ok");
                        break;
                    }
                }

                if (!found)
                {
                    // create the user info
                    Models.User newUser = new Models.User() { UserName = _UserText, Email = _EmailText, Password = _PasswordText };
                    String userInfo = JsonConvert.SerializeObject(newUser);

                    // save the credentials in local device staticly
                    Application.Current.Properties.Add("account", userInfo);
                    Console.WriteLine(userInfo);
                    Application.Current.SavePropertiesAsync();

                    // add to DB
                    firebaseClient.Child("Users").PostAsync(newUser);
                    await Application.Current.MainPage.DisplayAlert("Success", "Registered successfully", "OK");
                    await Navigation.PushModalAsync(new NavigationPage(new QuestionPage()));
                }
            }
        }
    }
}