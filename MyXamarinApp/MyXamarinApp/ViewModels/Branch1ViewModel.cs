using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyXamarinApp.Models;
using Xamarin.Forms;

namespace MyXamarinApp.ViewModels
{
    public class Branch1ViewModel : BaseViewModel
    {
        public ObservableCollection<QA> Branch1QAs { get; set; }
        public ICommand SubmitCommand { get; private set; }
        public ICommand RebranchCommand { get; private set; }
        public Branch1ViewModel()
        {
            // check whether logged in already
            if (!Application.Current.Properties.ContainsKey("account"))
            {
                // submit button
                SubmitCommand = new Command(ExecuteSubmitCommand);
                Branch1QAs = new ObservableCollection<QA>
                {
                    new QA
                    {
                        QuestionNumber = "B1Q1",
                        Question = "1. I always find new and interesting aspects in my work.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q2",
                        Question = "2. There are days when I feel tired before I arrive at work.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q3",
                        Question = "3. It happens more and more often that I talk about my work in a negative way.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q4",
                        Question = "4. After working, I tend to need more time than in the past in order to relax and feel better.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q5",
                        Question = "5. I can tolerate the pressure of my work very well.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q6",
                        Question = "6. Lately, I tend to think less at work and do my job almost mechanically.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q7",
                        Question = "7. I find my work to be a positive challenge.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q8",
                        Question = "8. During my work, I often feel emotionally drained.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q9",
                        Question = "9. Over time, one can become disconnected from this type of work.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q10",
                        Question = "10. After working, I have enough energy for my leisure activities.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q11",
                        Question = "11. Sometimes I feel sickened by my work tasks.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q12",
                        Question = "12. After my work, I usually feel worn out and weary.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q13",
                        Question = "13. This is the only type of work that I can imagine myself doing.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q14",
                        Question = "14. Usually, I can manage the amount of my work well.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q15",
                        Question = "15. I feel more and more engaged in my work.",
                        Selection = ""
                    },
                    new QA
                    {
                        QuestionNumber = "B1Q16",
                        Question = "16. When I work, I usually feel energized.",
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
            foreach (QA branchQA in Branch1QAs)
            {
                if (branchQA.Selection == "")
                {
                    flag = 0;
                }
            }

            if (flag == 1)
            {
                Application.Current.MainPage.DisplayAlert("Great!", "Submit Successfully!", "ok");
                Application.Current.Properties["branch12Complete"] = 1;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Not all questions are answered!", "dismiss");
            }
        }

    }
}



