using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace MyXamarinApp.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        private string _email;
        private string _password;

        public LogInViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        
        public void OnSubmit()
        {
            if (Email != "zih893@usask.ca" || Password != "13703853310Hzy")
            {
                DisplayInvalidLoginPrompt();

                Console.WriteLine("GOOOOODOOOOD!");
            }
        }
    }
}