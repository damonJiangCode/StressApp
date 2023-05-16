using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{
    public partial class Branch1Page : ContentPage
    {
        public Branch1ViewModel viewModel;

        public Branch1Page()
        {
            InitializeComponent();
            viewModel = new Branch1ViewModel();
            BindingContext = viewModel;
        }
    }
}

