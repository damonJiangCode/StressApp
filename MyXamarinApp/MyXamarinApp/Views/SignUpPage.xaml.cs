using MyXamarinApp.ViewModels;
using MyXamarinApp.Models;
using Xamarin.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using Xamarin.Essentials;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace MyXamarinApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        
        FirebaseClient firebaseClient;

        public SignUpPage()
        {
            InitializeComponent();
        }

        // jump to swipe card view page
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            // connect database
            firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");

            // check valid inputs
            if (String.IsNullOrEmpty(userName.Text))
            {
                await DisplayAlert("Alert", "You did not type your user name!", "OK");
            } else if (String.IsNullOrEmpty(email.Text))
            {
                await DisplayAlert("Alert", "You did not type your email!", "OK");
            }
            else if (String.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Alert", "You did not type your password!", "OK");
            }
            else if (String.IsNullOrEmpty(checkPassword.Text))
            {
                await DisplayAlert("Alert", "Please type your password again!", "OK");
            } else if (!checkPassword.Text.Equals(password.Text))
            {
                await DisplayAlert("Alert", "The password you typed does not match.", "OK");
            }

            // valid inputs
            else
            {
                // a flag
                bool found = false;

                // get data from DB
                var users = await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>();

                // check whether the user name has been used
                foreach (var user in users)
                {
                    if (user.Object.UserName.Equals(userName.Text))
                    {
                        found = true;
                        DisplayAlert("Alert", "User name has been used, please try again!", "ok");
                        break;
                    }
                }

                if (!found)
                {
                    // create the user info
                    User newUser = new User() { UserName = userName.Text, Email = email.Text, Password = password.Text };
                    var userInfo = JsonConvert.SerializeObject(newUser);

                    // save the credentials in local device staticly
                    Application.Current.Properties.Add("account", userInfo);
                    Application.Current.SavePropertiesAsync();

                    // add to DB
                    firebaseClient.Child("Users").PostAsync(newUser);
                    await DisplayAlert("Success", "Registered successfully", "OK");
                    await Navigation.PushModalAsync(new NavigationPage(new QuestionPage()));
                }
            }
        }
    }
}
