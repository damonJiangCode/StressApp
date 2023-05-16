using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{
    public partial class Branch5Page : ContentPage
    {
        public Branch5ViewModel viewModel;

        public Branch5Page()
        {
            InitializeComponent();
            viewModel = new Branch5ViewModel();
            BindingContext = viewModel;
        }
    }
}

