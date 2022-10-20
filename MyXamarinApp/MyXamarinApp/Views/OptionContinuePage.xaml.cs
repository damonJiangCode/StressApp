using Xamarin.Forms;
using MyXamarinApp.ViewModels;

namespace MyXamarinApp.Views
{
    public partial class OptionContinuePage : ContentPage
    {
        //private readonly NavigationPage MainPage;

        public OptionContinuePage()
        {
            BindingContext = new OptionContinueViewModel(Navigation);
            InitializeComponent();
        }

        async void LogButtonClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }

        async void SignButtonClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
