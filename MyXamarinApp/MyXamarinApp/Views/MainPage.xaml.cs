using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXamarinApp.ViewModels;
using MyXamarinApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        private MainViewModel vm;

        public MainPage()
        {
            InitializeComponent();
            vm = new MainViewModel(Navigation);
            BindingContext = vm;
        }
    }
}

