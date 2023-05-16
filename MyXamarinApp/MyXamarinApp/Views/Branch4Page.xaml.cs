using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{	
	public partial class Branch4Page : ContentPage
	{
        public Branch4ViewModel viewModel;

        public Branch4Page()
        {
            InitializeComponent();
            viewModel = new Branch4ViewModel();
            BindingContext = viewModel;
        }
    }
}

