using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyXamarinApp.Models;
using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{	
	public partial class QuestionReviewPage : ContentPage
	{
        public QuestionReviewViewModel viewModel;

        public QuestionReviewPage ()
		{
            InitializeComponent();
            viewModel = new QuestionReviewViewModel();
            BindingContext = viewModel;
        }

        void Branch12_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Branch1Page());
        }

        void Branch3_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Branch3Page());
        }

        void Branch4_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Branch4Page());
        }

        void Branch5_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Branch5Page());
        }

        void Branch6_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

