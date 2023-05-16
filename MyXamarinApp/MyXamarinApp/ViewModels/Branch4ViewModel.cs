using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyXamarinApp.Models;
using Xamarin.Forms;

namespace MyXamarinApp.ViewModels
{
    public class Branch4ViewModel : BaseViewModel
    {
        public ObservableCollection<QA> Branch4QAs { get; set; }
        public ICommand SubmitCommand { get; private set; }
        public Branch4ViewModel()
        {
            // check whether logged in already
            if (!Application.Current.Properties.ContainsKey("account"))
            {
                // submit button
                SubmitCommand = new Command(ExecuteSubmitCommand);
                Branch4QAs = new ObservableCollection<QA>
                {
                    new QA
                    {
                        QuestionNumber = "B4Q1",
                        Question = "1. I am bothered by fatigue",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q2",
                        Question = "2. I get tired very quickly",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q3",
                        Question = "3. I don’t do much during the day",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q4",
                        Question = "4. I have enough energy for everyday life",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q5",
                        Question = "5. Physically, I feel exhausted",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q6",
                        Question = "6. I have problems to start things",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q7",
                        Question = "7. I have problems to think clearly",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q8",
                        Question = "8. I feel no desire to do anything",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q9",
                        Question = "9. Mentally, I feel exhausted",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B4Q10",
                        Question = "10. When I am doing something, I can concentrate quite well",
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



