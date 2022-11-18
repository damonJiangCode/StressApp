using MyXamarinApp.Views;
using Xamarin.Forms;

namespace MyXamarinApp
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();
            MainPage = new QuestionPage();
            
        }

        protected override void OnStart ()
        {
            //if (Application.Current.Properties.ContainsKey("account"))
            //{
            //    MainPage = new NavigationPage(new MainPage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new LogInPage());
            //}
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
            
        }
    }
}

