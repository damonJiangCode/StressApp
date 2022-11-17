using System;
using System.Collections.Generic;
using MyXamarinApp.ViewModels;

using Xamarin.Forms;

namespace MyXamarinApp.Views
{	
	public partial class AccountPage : ContentPage
	{	
		public AccountPage ()
		{
			InitializeComponent();
			BindingContext = new AccountViewModel(Navigation);
        }
    }
}

