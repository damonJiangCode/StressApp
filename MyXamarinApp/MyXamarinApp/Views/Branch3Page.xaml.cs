using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{
    public partial class Branch3Page : ContentPage
    {
        public Branch3ViewModel viewModel;

        public Branch3Page()
        {
            InitializeComponent();
            viewModel = new Branch3ViewModel();
            BindingContext = viewModel;
        }
    }
}

