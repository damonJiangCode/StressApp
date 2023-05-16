using System;
using System.Windows.Input;
using Xamarin.Forms;
using MyXamarinApp.Views;

namespace MyXamarinApp.ViewModels
{
	
	public class MainViewModel : BaseViewModel
	{
        private readonly INavigation Navigation;

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
    }
}


