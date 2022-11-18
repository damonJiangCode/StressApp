using MLToolkit.Forms.SwipeCardView.Core;
using MyXamarinApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MyXamarinApp.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        ObservableCollection<string> _questions;
        int count = 0;
        private readonly INavigation Navigation;

        public QuestionViewModel(INavigation navigation)
        {
            _questions = new ObservableCollection<string>();
            _questions.Add("QUESTION_1");
            _questions.Add("QUESTION_2");
            _questions.Add("QUESTION_3");
            _questions.Add("QUESTION_4");
            _questions.Add("QUESTION_5");
            _questions.Add("QUESTION_6");
            _questions.Add("QUESTION_7");
            _questions.Add("Have a good one!");


            this.Navigation = navigation;
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
        }

        public ObservableCollection<string> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SwipedCommand { get; }

        // jump to another page when questions are answered
        async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            count++;
            if (count == 7)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        
    }
}