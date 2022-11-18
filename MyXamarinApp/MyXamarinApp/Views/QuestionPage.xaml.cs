using MyXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyXamarinApp.ViewModels;

namespace MyXamarinApp.Views
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(Navigation);
        }
    }
}
