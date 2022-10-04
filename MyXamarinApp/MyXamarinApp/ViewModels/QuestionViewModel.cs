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

        //string _message;

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
            ContinueCommand = new Command(async () => await OnContinueCommandAsync());
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
        }

        // get all questions of type string
        public ObservableCollection<string> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                RaisePropertyChanged();
            }
        }

        // a help texts to show something
        //public string Message
        //{
        //    get => _message;
        //    set
        //    {
        //        _message = value;
        //        RaisePropertyChanged();
        //    }
        //}

        // define commands with binding property in xmal file
        public ICommand SwipedCommand { get; }
        public Command ContinueCommand { get; }

        // function to jump to another page
        async Task OnContinueCommandAsync()
        {
            await Navigation.PushModalAsync(new OptionContinuePage(), true);
        }

        // jump to another page when questions are answered
        async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            count++;
            // var item = eventArgs.Item as string;
            // Message = $"{item} swiped {eventArgs.Direction} and count {count}";
            
            if (count == 1)
            {
                await OnContinueCommandAsync();
            }
        }
    }
}