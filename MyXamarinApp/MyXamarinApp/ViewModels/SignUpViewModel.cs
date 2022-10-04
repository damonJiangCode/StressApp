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
    public class SignUpViewModel : ContentPage
    {
        private string _userName;
        private string _email;
        private string _password;
        private string _firstName;
        private string _lastName;
        private int _phoneNumber;

        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
        }

        //private void Button_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    string path = AppDomain.CurrentDomain.BaseDirectory + @"myxamarinapp.json";
        //    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        //    FirestoreDb db = FirestoreDb.Create("myxamarinapp-28555");
        //    Debug.WriteLine("SUCCESSFUL!");
        //}

        // public Action DisplayInvalidLoginPrompt;
        // private string _email;
        // private string _password;

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
            Debug.WriteLine("SUCCESSFUL!");
        }
    }
}


