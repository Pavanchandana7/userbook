using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace UserBookServices
{
	public class UserClient
	{

		public async Task<User> GetUsers(int totalUser)
		{
			var uri = $"{Constants.BaseUrl}{totalUser}";
			var response = await this.GetAsync<User>(new Uri(uri));
			return response;
		}

		private async Task<T> GetAsync<T>(Uri uriValue)
		{

			if (uriValue == null)
			{
				throw new ArgumentNullException(nameof(uriValue));
			}

			using (var client = new HttpClient())
			{
				try
				{
				string result = await client.GetStringAsync(uriValue);
			    return JsonConvert.DeserializeObject<T>(result);
				}
				catch (Exception ex)
				{
					return default(T);
				}

			}
		}

	}
}
