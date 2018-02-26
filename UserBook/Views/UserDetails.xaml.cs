using System;
using System.Collections.Generic;
using UserBookServices;
using Xamarin.Forms;

namespace UserBook
{
	public partial class UserDetails : ContentPage
	{
		UserInfo user;
		public UserDetails(UserInfo user)
		{
			InitializeComponent();
			this.user = user;
			BindingContext = this.user;

			Title = $"{user.name.first} {user.name.last}";
		}
	}
}
