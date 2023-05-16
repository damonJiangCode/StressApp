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
        String _UserNameText;
        String _EmailText;
        String _PasswordText;
        String _ConfirmPasswordText;

        public SignUpViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

            // initialize empty strings
            _UserNameText = string.Empty;
            _EmailText = string.Empty;
            _PasswordText = string.Empty;
            _ConfirmPasswordText = string.Empty;

            // command for sign up
            SignupCommand = new Command(OnSignupCommand);
        }

        public String UserNameText
        {
            get => _UserNameText;
            set
            {
                _UserNameText = value;
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
            get => _ConfirmPasswordText;
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
            if (String.IsNullOrEmpty(_UserNameText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "User name is required!", "OK");
            }
            else if (String.IsNullOrEmpty(_EmailText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is required", "OK");
            }
            else if (String.IsNullOrEmpty(_PasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password is required", "OK");
            }
            else if (String.IsNullOrEmpty(_ConfirmPasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please confirm your password!", "OK");
            }
            else if (!_ConfirmPasswordText.Equals(_PasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match.", "OK");
            }

            // valid inputs
            else
            {
                // a flag to check whether the user name already exists
                bool found = false;

                // get data from DB
                var users = await firebaseClient
                    .Child("Users")
                    .OnceAsync<Models.User>();

                // check whether the user name has been used
                foreach (var user in users)
                {
                    if (user.Object.UserName.Equals(UserNameText))
                    {
                        found = true;
                        await Application.Current.MainPage.DisplayAlert("Error", "Choose a different user name!", "OK");
                        break;
                    } else if (user.Object.Email.Equals(EmailText))
                    {
                        found = true;
                        await Application.Current.MainPage.DisplayAlert("Error", "Choose a different user name!", "OK");
                    }
                }

                // if user name does not exist
                if (!found)
                {
                    // create the user info
                    Models.User newUser = new Models.User() { UserName = _UserNameText, Email = _EmailText, Password = _PasswordText };
                    String userInfo = JsonConvert.SerializeObject(newUser);

                    Application.Current.Properties.Add("account", userInfo);
                    Console.WriteLine(userInfo);
                    Application.Current.SavePropertiesAsync();
                    
                    // add to DB
                    firebaseClient.Child("Users").PostAsync(newUser);
                    await Application.Current.MainPage.DisplayAlert("Success", "Registered successfully!", "OK");

                    await Application.Current.MainPage.DisplayAlert("Questions", "Please answer some questions!", "OK");
                    await Navigation.PushModalAsync(new NavigationPage(new QuestionPage()));
                }
            }
        }
    }
}