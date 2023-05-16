using System;
using System.Collections.Generic;

namespace MyXamarinApp.ViewModels
{
	public class ResourceViewModel:BaseViewModel
	{
		private List<string> _TopItems;
		public List<string> TopItems
		{
			get => _TopItems;
			set
			{
				_TopItems = value;
				RaisePropertyChanged();
			}
		}

        private List<string> _BottomItems;
        public List<string> BottomItems
        {
            get => _BottomItems;
            set
            {
                _BottomItems = value;
                RaisePropertyChanged();
            }
        }


        public ResourceViewModel()
        { 
			_TopItems = new List<string>();
			_TopItems.Add("A");
            _TopItems.Add("B");
            _TopItems.Add("C");
            _TopItems.Add("D");

            _BottomItems = new List<string>();
            _BottomItems.Add("E");
            _BottomItems.Add("F");
            _BottomItems.Add("G");
            _BottomItems.Add("H");

        }
	}
}

