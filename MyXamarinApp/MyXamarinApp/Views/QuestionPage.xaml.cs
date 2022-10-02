using Xamarin.Forms;
using MyXamarinApp.ViewModels;

namespace MyXamarinApp.Views
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel();
        }

        void LogInButton_Clicked(System.Object sender, System.EventArgs e)
        {
          
        }
    }
}
