using Xamarin.Forms;
using MyXamarinApp.ViewModels;

namespace MyXamarinApp.Views
{
    public partial class QuestionPage : ContentPage
    {

        public QuestionPage()
        {
            BindingContext = new QuestionViewModel(Navigation);
            InitializeComponent();
        }
    }
}
