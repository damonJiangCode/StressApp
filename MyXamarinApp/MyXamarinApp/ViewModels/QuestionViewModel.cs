using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyXamarinApp.Views;

namespace MyXamarinApp.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        private ObservableCollection<string> _cardItems;
        public int count;
        private readonly INavigation Navigation;

        public QuestionViewModel(INavigation navigation)
        {
            _cardItems = new ObservableCollection<string>();

            _cardItems.Add("Have you often felt emotionally drained?");
            _cardItems.Add("Have you felt less and less engaged by work?");
            _cardItems.Add("Have you felt little interest or pleasure in doing things?");
            _cardItems.Add("Have you found yourself falling asleep while not stimulated or active?");
            _cardItems.Add("Have you found that you could not cope with all the things that you need to do?");
            _cardItems.Add("Did poor mental health keep you from doing your usual activities, such as self care, work, or recreation?");
            _cardItems.Add("Did poor physical health keep you from doing your usual activities, such as self care, work, or recreation?");
            _cardItems.Add("Ready to manage your stress!!!");

            this.Navigation = navigation;
            count = 0;
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);

        }

        public ObservableCollection<string> CardItems
        {
            get => _cardItems;
            set
            {
                _cardItems = value;
                RaisePropertyChanged();
            }
        }


        public ICommand SwipedCommand { get; }

        private async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            count++;
            if (count == 7)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        
    }
}
