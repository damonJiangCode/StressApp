using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyXamarinApp.Views;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.ComponentModel;
using Xamarin.Essentials;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using MyXamarinApp.Models;

namespace MyXamarinApp.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        readonly FirebaseClient firebaseClient;
        private ObservableCollection<string> _cardItems;
        public List<string> questions;
        public int count;
        public int branch;
        public int percentage;
        public List<string> answers;
        private uint _threshold;
        private readonly INavigation Navigation;
        public List<QA> starterQAs;
        
        public QuestionViewModel(INavigation navigation)
        {
            firebaseClient = new FirebaseClient("https://myxamarinapp-331dd-default-rtdb.firebaseio.com/");
            this.Navigation = navigation;
            _cardItems = new ObservableCollection<string>();
            questions = new List<string>();
            // 7 basic questions for new users
            _cardItems.Add("Have you often felt emotionally drained?");
            _cardItems.Add("Have you felt less and less engaged by work?");
            _cardItems.Add("Have you felt little interest or pleasure in doing things?");
            _cardItems.Add("Have you found yourself falling asleep while not stimulated or active?");
            _cardItems.Add("Have you found that you could not cope with all the things that you need to do?");
            _cardItems.Add("Did poor mental health keep you from doing your usual activities, such as self care, work, or recreation?");
            _cardItems.Add("Did poor physical health keep you from doing your usual activities, such as self care, work, or recreation?");
            questions = _cardItems.ToList<string>();
            count = 0;
            branch = 0;
            percentage = 0;
            answers = new List<string>();
            starterQAs = new List<QA>();

            var metrics = DeviceDisplay.MainDisplayInfo;
            float screenWidthDp = (float)metrics.Width / (float)metrics.Density;

            Threshold = (uint)(screenWidthDp / 3);

            this.Navigation = navigation;

            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
            DraggingCommand = new Command<DraggingCardEventArgs>(OnDraggingCommand);
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

        public uint Threshold
        {
            get => _threshold;
            set
            {
                _threshold = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SwipedCommand { get; }

        public ICommand DraggingCommand { get;  }

        private async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            // for starter
            if (branch == 0)
            {
                count++;

                if (eventArgs.Direction.ToString().Equals("Left"))
                {
                    answers.Add("no");
                }
                else if (eventArgs.Direction.ToString().Equals("Right"))
                {
                    answers.Add("yes");
                    percentage += 1;
                }

                // add answers
                if (count == 7)
                {
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ1",
                        Question = "Have you often felt emotionally drained ? ",
                        Selection = answers[0]
                    }) ;
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ2",
                        Question = "Have you felt less and less engaged by work?",
                        Selection = answers[1]
                    });
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ3",
                        Question = "Have you felt little interest or pleasure in doing things?",
                        Selection = answers[2]
                    });
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ4",
                        Question = "Have you found yourself falling asleep while not stimulated or active?",
                        Selection = answers[3]
                    });
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ5",
                        Question = "Have you found that you could not cope with all the things that you need to do?",
                        Selection = answers[4]
                    });
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ6",
                        Question = "Did poor mental health keep you from doing your usual activities, such as self care, work, or recreation?",
                        Selection = answers[5]
                    });
                    starterQAs.Add(new QA
                    {
                        QuestionNumber = "SQ7",
                        Question = "Did poor physical health keep you from doing your usual activities, such as self care, work, or recreation?",
                        Selection = answers[6]
                    });

                    // get string value
                    String userToString = Application.Current.Properties["account"].ToString();

                    // cast to user object
                    Models.User user = JsonConvert.DeserializeObject<Models.User>(userToString);
                    // save the answers
                    user.StarterQuestions = starterQAs;

                    // cast to Json 
                    String castUser = JsonConvert.SerializeObject(user);

                    // save in local device
                    Application.Current.Properties["account"] = castUser;
                    Application.Current.SavePropertiesAsync();

                    ///////////////////////////////////////////////
                    //String userInfoStringUpdated = Application.Current.Properties["account"].ToString();
                    //Console.WriteLine("USER STRING WITH STARTER ANSWERS!");
                    //Console.WriteLine(userInfoStringUpdated);

                    // update the starter questions
                    var toUpdate = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<Models.User>()).Where(a => a.Object.UserName == user.UserName).FirstOrDefault();

                    // update answers and percentage
                    toUpdate.Object.StarterQuestions = user.StarterQuestions;

                    //update the new value
                    await firebaseClient
                    .Child("Users")
                    .Child(toUpdate.Key)
                    .PutAsync(toUpdate.Object);

                    //bool answer = await Application.Current.MainPage.DisplayAlert("Question?", "Would you like to go to another question set?", "yes", "no");

                    //if (answer)
                    //{
                    //    branch = 1;
                    //    answers.Clear();
                    //    count = 0;
                    //    percentage = 0;
                    //    _cardItems.Clear();
                    //    _cardItems.Add("branch 1 question 1");
                    //    _cardItems.Add("branch 1 question 2");
                    //    _cardItems.Add("branch 1 question 3");
                    //    _cardItems.Add("branch 1 question 4");
                    //    _cardItems.Add("branch 1 question 5");
                    //    _cardItems.Add("branch 1 question 6");
                    //    _cardItems.Add("branch 1 question 7");
                    //    questions = _cardItems.ToList<string>();
                    //}

                    //else
                    //{
                    //    await Navigation.PushAsync(new MainPage());
                    //}
                    await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                }
            } else
            {
                throw new Exception("ERROR: starter questions error.");
            }
            //else if (branch == 1)
            //{
            //    count++;

            //    if (eventArgs.Direction.ToString().Equals("Left"))
            //    {
            //        answers.Add("no");
            //    }
            //    else if (eventArgs.Direction.ToString().Equals("Right"))
            //    {
            //        answers.Add("yes");
            //        percentage += 1;
            //    }

            //    // add answers
            //    if (count == 7)
            //    {
            //        // get string value
            //        String userInfoString = Application.Current.Properties["account"].ToString();

            //        // cast to user object
            //        Models.User userInfo = JsonConvert.DeserializeObject<Models.User>(userInfoString);

            //        // save the questions
            //        userInfo.Branch1Questions = questions;

            //        // save the answers
            //        userInfo.Branch1Answers = answers;

            //        // save the percentage
            //        userInfo.Branch1Percentage = (percentage * 100) / 7 + "%";

            //        // cast to Json 
            //        String castUser = JsonConvert.SerializeObject(userInfo);

            //        // save in local device
            //        Application.Current.Properties["account"] = castUser;
            //        Application.Current.SavePropertiesAsync();

            //        ////////////////////////////////////////////////////
            //        //String userInfoStringUpdated = Application.Current.Properties["account"].ToString();
            //        //Console.WriteLine("USER STRING WITH STARTER & BRANCH1 ANSWERS!");
            //        //Console.WriteLine(userInfoStringUpdated);

            //        // find the object
            //        var toUpdate = (await firebaseClient
            //        .Child("Users")
            //        .OnceAsync<Models.User>()).Where(a => a.Object.UserName == userInfo.UserName).FirstOrDefault();

            //        // update the branch1 answers and percentage
            //        toUpdate.Object.Branch1Answers = userInfo.Branch1Answers;
            //        toUpdate.Object.Branch1Percentage = userInfo.Branch1Percentage;
            //        toUpdate.Object.Branch1Questions = userInfo.Branch1Questions;

            //        //update the new value
            //        await firebaseClient
            //        .Child("Users")
            //        .Child(toUpdate.Key)
            //        .PutAsync(toUpdate.Object);

            //        bool answer = await Application.Current.MainPage.DisplayAlert("Question?", "Would you like to go to another question set?", "yes", "no");

            //        if (answer)
            //        {
            //            // clear storege and add new questions
            //            branch = 2;
            //            answers.Clear();
            //            count = 0;
            //            percentage = 0;
            //            _cardItems.Clear();
            //            _cardItems.Add("branch 2 question 1");
            //            _cardItems.Add("branch 2 question 2");
            //            _cardItems.Add("branch 2 question 3");
            //            _cardItems.Add("branch 2 question 4");
            //            _cardItems.Add("branch 2 question 5");
            //            _cardItems.Add("branch 2 question 6");
            //            _cardItems.Add("branch 2 question 7");
            //            questions = _cardItems.ToList<string>();
            //        }
            //        else
            //        {
            //            await Navigation.PushAsync(new MainPage());
            //        }
            //    }

            //}
            //else if (branch == 2)
            //{
            //    count++;

            //    if (eventArgs.Direction.ToString().Equals("Left"))
            //    {
            //        answers.Add("no");
            //    }
            //    else if (eventArgs.Direction.ToString().Equals("Right"))
            //    {
            //        answers.Add("yes");
            //        percentage += 1;
            //    }

            //    // add answers
            //    if (count == 7)
            //    {
            //        // get string value
            //        String userInfoString = Application.Current.Properties["account"].ToString();
            //        ////////////////////////////////////////////
            //        //Console.WriteLine("USER STRING WITH STARTER & BRANCH1 ANSWERS!");
            //        //Console.WriteLine(userInfoString);

            //        // cast to user object
            //        Models.User userInfo = JsonConvert.DeserializeObject<Models.User>(userInfoString);

            //        // save the answers
            //        userInfo.Branch2Answers = answers;
            //        userInfo.Branch2Percentage = (percentage * 100) / 7 + "%";
            //        userInfo.Branch2Questions = questions;

            //        // cast to Json 
            //        String castUser = JsonConvert.SerializeObject(userInfo);

            //        // save in local device
            //        Application.Current.Properties["account"] = castUser;
            //        Application.Current.SavePropertiesAsync();

            //        // update the branch2 questions and percentage
            //        var toUpdate = (await firebaseClient
            //        .Child("Users")
            //        .OnceAsync<Models.User>()).Where(a => a.Object.UserName == userInfo.UserName).FirstOrDefault();

            //        toUpdate.Object.Branch2Answers = userInfo.Branch2Answers;
            //        toUpdate.Object.Branch2Percentage = userInfo.Branch2Percentage;
            //        toUpdate.Object.Branch2Questions = userInfo.Branch2Questions;
            //        //update the new value
            //        await firebaseClient
            //        .Child("Users")
            //        .Child(toUpdate.Key)
            //        .PutAsync(toUpdate.Object);

            //        await Navigation.PushAsync(new MainPage());
            //    }
            //}
        }

        private void OnDraggingCommand(DraggingCardEventArgs eventArgs)
        {
            switch (eventArgs.Position)
            {
                case DraggingCardPosition.Start:
                    return;

                case DraggingCardPosition.UnderThreshold:
                    break;

                case DraggingCardPosition.OverThreshold:
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    return;

                case DraggingCardPosition.FinishedOverThreshold:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
