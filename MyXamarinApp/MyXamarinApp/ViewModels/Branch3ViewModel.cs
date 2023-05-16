using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyXamarinApp.Models;
using Xamarin.Forms;

namespace MyXamarinApp.ViewModels
{
    public class Branch3ViewModel : BaseViewModel
    {
        public ObservableCollection<QA> Branch3QAs { get; set; }
        public ICommand SubmitCommand { get; private set; }
        public Branch3ViewModel()
        {
            // check whether logged in already
            if (!Application.Current.Properties.ContainsKey("account"))
            {
                // submit button
                SubmitCommand = new Command(ExecuteSubmitCommand);
                Branch3QAs = new ObservableCollection<QA>
                {
                    new QA
                    {
                        QuestionNumber = "B3Q1",
                        Question = "1. Little interest or pleasure in doing things",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q2",
                        Question = "2. Feeling down, depressed, or hopeless",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q3",
                        Question = "3. Trouble falling or staying asleep, or sleeping too much",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q4",
                        Question = "4. Feeling tired or having little energy",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q5",
                        Question = "5. Poor appetite or overeating",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q6",
                        Question = "6. Feeling bad about yourself – or that you are a failure or have let yourself or your family down",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q7",
                        Question = "7. Trouble concentrating on things, such as reading the newspaper or watching television",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q8",
                        Question = "8. Moving or speaking so slowly that other people could have noticed? Or the opposite – being so fidgety or restless that you have been moving around a lot more than usual",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B3Q9",
                        Question = "9. Thoughts that you would be better off dead or of hurting yourself in some way",
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
            foreach (QA branchQA in Branch3QAs)
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



