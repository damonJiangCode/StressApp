using MyXamarinApp.ViewModels;
using Xamarin.Forms;


namespace MyXamarinApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            // BindingContext = new SignUpViewModel(Navigation);
            InitializeComponent();
        }

        // jump to swipe card view page
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //if (UserName.Text == "Damon" && Password.Text == "1234")
            //{
            //    await Navigation.PushModalAsync(new MainPage());
            //}
            //else
            //{
            //    await DisplayAlert("Alert", "User name or password is incorrect!", "ok");
            //}
            //    if (Password.Text == CheckPassword.Text)
            //    {

            //    } else
            //    {
            //        await DisplayAlert("Alert", "The password you typed does not match.", "ok");
            //    }
            //
            await Navigation.PushAsync(new QuestionPage());
        }
    }
}

