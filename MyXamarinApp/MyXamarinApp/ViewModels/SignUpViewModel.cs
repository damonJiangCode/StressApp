using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using MyXamarinApp.ViewModels;
using Google.Cloud.Firestore;
using System.Diagnostics;
using System.Windows.Input;

namespace MyXamarinApp.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        //private string _userName;
        //private string _email;
        //private string _password;
        //private string _firstName;
        //private string _lastName;
        //private int _phoneNumber;
        private readonly INavigation Navigation;


        public SignUpViewModel()
        {
            //this.Navigation = navigation;
            SignUpCommand = new Command(OnSignUp);
        }

        public ICommand SignUpCommand { protected set; get; }


        public void OnSignUp()
        {
            //if (Email != "macoratti@yahoo.com" || Password != "secret")
            //{
            //    DisplayInvalidLoginPrompt();
            //}
            string path = AppDomain.CurrentDomain.BaseDirectory + @"MyXamarinApp.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            FirestoreDb db = FirestoreDb.Create("myxamarinapp-28555");

            // Console.WriteLine("CONNECTION WORKS!!!!!!!!");

            //DocumentReference docRef = db.Collection("accountinfo").Document("yUIEgRkpwToFT9jJcVOw");
            //Dictionary<string, object> user = new Dictionary<string, object>
            //{
            //    { "Email", "b" },
            //    { "UserName", "b" }
            //};
            //await docRef.SetAsync(user);
        }
    }
}


