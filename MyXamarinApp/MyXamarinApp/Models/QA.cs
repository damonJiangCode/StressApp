using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyXamarinApp.Models
{
    public class QA : INotifyPropertyChanged
    {
        private string _QuestionNumber;
        public string QuestionNumber
        {
            get => _QuestionNumber;
            set
            {
                _QuestionNumber = value;
                RaisePropertyChanged();
            }
        }

        private string _Question;
        public string Question
        {
            get => _Question;
            set
            {
                _Question = value;
                RaisePropertyChanged();
            }
        }

        private string _Selection;
        public string Selection
        {
            get => _Selection;
            set
            {
                _Selection = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

