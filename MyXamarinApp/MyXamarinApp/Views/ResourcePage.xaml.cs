using System;
using System.Collections.Generic;
using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{	
	public partial class ResourcePage : ContentPage
	{
		private ResourceViewModel vm;

		public ResourcePage ()
		{
			InitializeComponent ();
			vm = new ResourceViewModel();
			BindingContext = vm;
		}
	}
}

