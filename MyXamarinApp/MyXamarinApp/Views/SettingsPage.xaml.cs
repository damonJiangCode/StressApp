using System;
using System.Collections.Generic;
using MyXamarinApp.ViewModels;

using Xamarin.Forms;

namespace MyXamarinApp.Views
{	
	public partial class SettingsPage : ContentPage
	{	
		public SettingsPage ()
		{
			InitializeComponent();
			BindingContext = new SettingsViewModel(Navigation);
        }
    }
}

