using Xamarin.Forms;
using MyXamarinApp.ViewModels;
using System;

namespace MyXamarinApp.Views
{
    public partial class OptionContinuePage : ContentPage
    {
        

        public OptionContinuePage()
        {
            InitializeComponent();
            BindingContext = new OptionContinueViewModel();
        }
    }
}

