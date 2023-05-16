using System;
using MyXamarinApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyXamarinApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("account"))
            {
                Application.Current.Properties.Clear();
            }
            if (Application.Current.Properties.ContainsKey("branch12Complete"))
            {
                Application.Current.Properties.Clear();
            }
            MainPage = new NavigationPage(new QuestionReviewPage());

            //if (Application.Current.Properties.ContainsKey("account"))
            //{
            //    //Application.Current.Properties.Remove("account");
            //    MainPage = new NavigationPage(new LogInPage());
            //    Console.WriteLine("-----------------------");
            //    Console.WriteLine("ACCOUNT FOUND!!");
            //    string userInfoString = Application.Current.Properties["account"].ToString();
            //    Models.User userInfo = JsonConvert.DeserializeObject<Models.User>(userInfoString);
            //    Console.WriteLine("------------------------");
            //    Console.WriteLine("ACCOUNT SAVED IN THIS DEVICE: " + userInfoString);
            //    Console.WriteLine();
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new LogInPage());
            //}
            

        }

        protected override void OnStart ()
        {

        }

        protected override void OnSleep ()
        {

        }

        protected override void OnResume ()
        {
            
        }
    }
}

