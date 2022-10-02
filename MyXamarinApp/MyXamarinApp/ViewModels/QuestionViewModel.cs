using MLToolkit.Forms.SwipeCardView.Core;
using MyXamarinApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyXamarinApp.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        private ObservableCollection<string> _questions;
        private bool _isLoopCards;
        private string _message;

        public QuestionViewModel()
        {
            _questions = new ObservableCollection<string>();

            _questions.Add("QUESTION_1");
            _questions.Add("QUESTION_2");
            _questions.Add("QUESTION_3");
            _questions.Add("QUESTION_4");
            _questions.Add("QUESTION_5");
            _questions.Add("QUESTION_6");
            _questions.Add("QUESTION_7");
            _questions.Add("HYPERLINK!");
            _isLoopCards = false;
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

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoopCards
        {
            get => _isLoopCards;
            set
            {
                _isLoopCards = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SwipedCommand { get; }

        private void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            var item = eventArgs.Item as string;
            Message = $"{item} swiped {eventArgs.Direction}";
        }


        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            NavigationPage navigationPage = new NavigationPage(new LogInPage());
        }
    }
}