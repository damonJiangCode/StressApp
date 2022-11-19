using System;
using System.Windows.Input;
using Firebase.Database;
using Xamarin.Forms;
using MyXamarinApp.Models;
using MyXamarinApp.Views;
using Newtonsoft.Json;

namespace MyXamarinApp.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        private readonly INavigation Navigation;
        readonly FirebaseClient firebaseClient;
        String _UserText;
        String _PasswordText;

        public LogInViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

            _UserText = String.Empty;
            _PasswordText = String.Empty;

            LoginCommand = new Command(OnLoginCommand);
            TapCommand = new Command(OnTapCommand);

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

        public String PasswordText
        {
            get => _PasswordText;
            set
            {
                _PasswordText = value;
                RaisePropertyChanged();
            }
        }

        public Command LoginCommand { get; }

        public async void OnLoginCommand()
        {
            // get data from DB
            var userList = await firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            // check whether credentials exist
            bool found = false;

            // check credentials
            foreach (var user in userList)
            {
                if (user.Object.UserName.Equals(_UserText) && user.Object.Password.Equals(_PasswordText))
                {
                    // store the credentials to local device
                    var userInfo = JsonConvert.SerializeObject(user);
                    Application.Current.Properties.Add("account", userInfo);
                    Application.Current.SavePropertiesAsync();
                    found = true;
                    await Navigation.PushAsync(new MainPage());
                }
            }
            if (!found)
                Application.Current.MainPage.DisplayAlert("Alert", "User name or password is incorrect!", "ok");
        }

        public Command TapCommand { get; }

        public async void OnTapCommand()
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
