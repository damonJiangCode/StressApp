using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyXamarinApp.ViewModels
{
	public class ProfileViewModel
	{
		public char Char { get; set; }
		public Models.User user { get; set; }

		public ProfileViewModel()
		{
			if (Application.Current.Properties.ContainsKey("account"))
			{
				string userToString = Application.Current.Properties["account"].ToString();
				user = JsonConvert.DeserializeObject<Models.User>(userToString);
				Char = user.UserName[0];
            }
		}
	}
}

