using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyXamarinApp.Models
{
    public class User : INotifyPropertyChanged
    {
        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;
                RaisePropertyChanged();
            }
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set
            {
                _Email = value;
                RaisePropertyChanged();
            }
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                RaisePropertyChanged();
            }
        }

        private string _Gender;
        public string Gender
        {
            get => _Gender;
            set
            {
                _Gender = value;
                RaisePropertyChanged();
            }
        }

        private string _Birthday;
        public string Birthday
        {
            get => _Birthday;
            set
            {
                _Birthday = value;
                RaisePropertyChanged();
            }
        }

        private List<QA> _StarterQuestions;
        public List<QA> StarterQuestions
        {
            get => _StarterQuestions;
            set
            {
                _StarterQuestions = value;
                RaisePropertyChanged();
            }
        }

        private List<QA> _BranchQuestions;
        public List<QA> BranchQuestions
        {
            get => _BranchQuestions;
            set
            {
                _BranchQuestions = value;
                RaisePropertyChanged();
            }
        }

        // public List<string> StarterQuestions { get; set; }
        //public List<string> Branch1Questions { get; set; }
        //public List<string> Branch2Questions { get; set; }

        //public String StarterPercentage { get; set; }
        //public String Branch1Percentage { get; set; }
        //public String Branch2Percentage { get; set; }

        //public List<string> StarterAnswers { get; set; }
        //public List<string> Branch1Answers { get; set; }
        //public List<string> Branch2Answers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
