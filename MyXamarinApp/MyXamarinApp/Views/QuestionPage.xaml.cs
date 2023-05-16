using MLToolkit.Forms.SwipeCardView.Core;
using MyXamarinApp.Models;
using MyXamarinApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(Navigation);
            SwipeCardView.Dragging += OnDragging;
        }

        private void OnDragging(object sender, DraggingCardEventArgs e)
        {
            var view = (Xamarin.Forms.View)sender;
            var noFrame = view.FindByName<Frame>("NoFrame");
            var yesFrame = view.FindByName<Frame>("YesFrame");
            var threshold = (BindingContext as QuestionViewModel).Threshold;

            var draggedXPercent = e.DistanceDraggedX / threshold;

            // var draggedYPercent = e.DistanceDraggedY / threshold;

            switch (e.Position)
            {
                case DraggingCardPosition.Start:
                    // Console.WriteLine("POSITION START");
                    noFrame.Opacity = 0;
                    yesFrame.Opacity = 0;
                    break;

                case DraggingCardPosition.UnderThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        // Console.WriteLine("POSITION UNDER THRESHOLD AND DRAGGING LEFT");
                        // Console.WriteLine(draggedXPercent);
                        noFrame.Opacity = (-1) * draggedXPercent;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        // Console.WriteLine("POSITION UNDER THRESHOLD AND DRAGGING RIGHT");
                        // Console.WriteLine(draggedXPercent);
                        yesFrame.Opacity = draggedXPercent;
                    }
                    break;

                case DraggingCardPosition.OverThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        // Console.WriteLine("POSITION OVER THRESHOLD AND DRAGGING LEFT");
                        noFrame.Opacity = 1;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        // Console.WriteLine("POSITION OVER THRESHOLD AND DRAGGING RIGHT");
                        yesFrame.Opacity = 1;
                    }
                    
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    // Console.WriteLine("POSITION FINISHED UNDER THRESHOLD.");
                    noFrame.Opacity = 0;
                    yesFrame.Opacity = 0;
                    break;

                case DraggingCardPosition.FinishedOverThreshold:
                    // Console.WriteLine("POSITION FINISHED OVER THRESHOLD");
                    noFrame.Opacity = 0;
                    yesFrame.Opacity = 0;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
