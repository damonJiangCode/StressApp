using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyXamarinApp.Views
{	
	public partial class ProfilePage : ContentPage
	{	
		public ProfilePage ()
		{
			InitializeComponent ();
            birthDatePicker.Date = DateTime.Today;
            birthDatePicker.MaximumDate = DateTime.Today;
        }
	}
}

