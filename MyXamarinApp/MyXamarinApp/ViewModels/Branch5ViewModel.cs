using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyXamarinApp.Models;
using Xamarin.Forms;

namespace MyXamarinApp.ViewModels
{
    public class Branch5ViewModel : BaseViewModel
    {
        public ObservableCollection<QA> Branch5QAs { get; set; }
        public ICommand SubmitCommand { get; private set; }
        public Branch5ViewModel()
        {
            // check whether logged in already
            if (!Application.Current.Properties.ContainsKey("account"))
            {
                // submit button
                SubmitCommand = new Command(ExecuteSubmitCommand);
                Branch5QAs = new ObservableCollection<QA>
                {
                    new QA
                    {
                        QuestionNumber = "B5Q1",
                        Question = "1. In the last month, how often have you been upset because of something that happened unexpectedly?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q2",
                        Question = "2. In the last month, how often have you felt that you were unable to control the important things in your life?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q3",
                        Question = "3. In the last month, how often have you felt nervous and stressed?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q4",
                        Question = "4. In the last month, how often have you felt confident about your ability to handle your personal problems?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q5",
                        Question = "5. In the last month, how often have you felt that things were going your way?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q6",
                        Question = "6. In the last month, how often have you found that you could not cope with all the things that you had to do?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q7",
                        Question = "7. In the last month, how often have you been able to control irritations in your life?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q8",
                        Question = "8. In the last month, how often have you felt that you were on top of things?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q9",
                        Question = "9. In the last month, how often have you been angered because of things that happened that were outside of your control?",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B5Q10",
                        Question = "10. In the last month, how often have you felt difficulties were piling up so high that you could not overcome them?",
                        Selection = ""
                    }
                };
            }
            else
            {
                throw new Exception("No account information is stored in this device!");
            }
        }

        // submit button excutation
        private void ExecuteSubmitCommand(object obj)
        {
            int flag = 1;

            foreach (QA branchQA in Branch4QAs)
            {
                if (branchQA.Selection == "")
                {
                    flag = 0;
                }
            }

            if (flag == 1)
            {
                Application.Current.MainPage.DisplayAlert("Great!", "Submit Successfully!", "ok");
                // Application.Current.Properties["branch12Complete"] = 1;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Not all questions are answered!", "dismiss");
            }
        }

    }
}


