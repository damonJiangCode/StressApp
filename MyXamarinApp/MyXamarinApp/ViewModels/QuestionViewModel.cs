using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyXamarinApp.Views;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Collections;

namespace MyXamarinApp.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        private ObservableCollection<string> _cardItems;
        public int count;
        private readonly INavigation Navigation;
        public readonly List<string> answers;

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

            count = 0;
            this.Navigation = navigation;
            answers = new List<string>(7);
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
            
            if (eventArgs.Direction.ToString().Equals("Left"))
            {
                answers.Add("no");
            }
            else if (eventArgs.Direction.ToString().Equals("Right"))
            {
                answers.Add("yes");
            }

            if (count == 7)
            {
                if (Application.Current.Properties.ContainsKey("account"))
                {
                    // get string value
                    String userString = Application.Current.Properties["account"].ToString();
                    // Console.WriteLine(userString);

                    // cast to user object
                    Models.User userObject = JsonConvert.DeserializeObject<Models.User>(userString);

                    // save the answers
                    userObject.Answers = answers;

                    // cast to Json 
                    String castUser = JsonConvert.SerializeObject(userObject);

                    // save in local device
                    Application.Current.Properties["account"] = castUser;

                    Application.Current.SavePropertiesAsync();

                    //String userString2 = Application.Current.Properties["account"] as string;
                    //Console.WriteLine(userString2);
                }
                await Navigation.PushAsync(new MainPage());
            }
        }

        
    }
}
