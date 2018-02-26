using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserBookServices;
using Xamarin.Forms;

namespace UserBook
{
	public partial class HomePage : ContentPage
	{
		
		UserClient userClient = new UserClient();

		User user = null;

		public HomePage()
		{
			InitializeComponent();
			Title = "Home";
			NavigationPage.SetHasNavigationBar(this, false);
		}

		private async void GetUsersBtn_Clicked(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(TotalUsersTextBox.Text))
			{
				int totalRecords = Convert.ToInt16(TotalUsersTextBox.Text);
				if (totalRecords<=20)
				{
					actIndicator2.IsRunning = true;
					user = await userClient.GetUsers(totalRecords);
					UsersListView.ItemsSource = user.results;
					actIndicator2.IsRunning = false;
				}
				else
				{
                    DisplayAlert("Error", "Enter value between 0 to 20", "OK");
				}
			}
			else
			{
				DisplayAlert("Error", "Enter no.of records to show", "OK");
			}


		}

		public async Task GetUsers(int totalUsers)
		{
			user = await userClient.GetUsers(totalUsers);
			var userList = user.results;

		}


			async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
			{
				var item = e.SelectedItem as UserInfo;
			if (item == null)
				return;

				await Navigation.PushAsync(new UserDetails(item));

			// Manually deselect item
				UsersListView.SelectedItem = null;	
			}

	}
}
