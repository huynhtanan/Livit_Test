using System;
using System.Text;
using System.Threading.Tasks;
using Abc.Api.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;

namespace Abc.Api.GoogleHelpers
{
	public static class APIHelper
	{
		public static GoogleAPIToken GetAccessToken(string returnUrl, string code)
		{
			var url = "https://www.googleapis.com/oauth2/v4/token?";
			var clientId = GoogleAPIInfo.ClientID;
			var clientSecret = GoogleAPIInfo.ClientSecret;
			var redirectUrl = returnUrl;
			var tokenUrl = url + "client_id=" + clientId + "&client_secret=" + clientSecret + "&redirect_uri=" + redirectUrl + "&code=" + code + "&grant_type=authorization_code";

			var client = new HttpClient();
			client.BaseAddress = new Uri(tokenUrl);
			HttpContent contentPost = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");
			Task<HttpResponseMessage> response = client.PostAsync("", contentPost);
			var result = response.Result.Content.ReadAsStringAsync().Result;

			var ApiToken = JsonConvert.DeserializeObject<GoogleAPIToken>(result);
			return ApiToken;
		}
		public static GoogleAPIUserInfo GetUserInfo(string token)
		{
			var url = "https://www.googleapis.com/oauth2/v1/userinfo?";
			var endPoint = url + "access_token=" + token;

			var client = new HttpClient();
			client.BaseAddress = new Uri(endPoint);
			Task<HttpResponseMessage> response = client.GetAsync("");
			var result = response.Result.Content.ReadAsStringAsync().Result;

			var userInfo = JsonConvert.DeserializeObject<GoogleAPIUserInfo>(result);
			return userInfo;
		}
	}
}
