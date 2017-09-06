using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HybridView.Models;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace HybridView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            Title = "Login";
            
		}

        async Task doLogin(object sender, EventArgs e)
        {
            btnLogin.IsEnabled = false;

            try
            {
                if (usernameEntry.Text.Equals(string.Empty) || passwordEntry.Text.Equals(string.Empty))
                {
                    await DisplayAlert("Error", "Please provide your username and password", "Ok");
                    return;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Please provide your username and password", "Ok");
                btnLogin.IsEnabled = true;
                throw;
            }



            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var uri = new Uri(string.Format(App.baseUrl + "api/user/login", string.Empty));
            var json = new JObject(new JProperty("username", usernameEntry.Text), new JProperty("password", passwordEntry.Text)).ToString();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

         
            Task<HttpResponseMessage> getResponse = client.PostAsync(uri, content);
            // Wait for the response and read it to a string var

            HttpResponseMessage response = await getResponse;
            //var responseStr = await response.Content.ReadAsStringAsync();



            if (response.IsSuccessStatusCode)
            {

                var responseString = await response.Content.ReadAsStringAsync();
                var login = JsonConvert.DeserializeObject<ClsLoginResponse>(responseString);

                if (login.errorCode == 1)
                {
                    await DisplayAlert("Invalid credentials", "Username or password is incorrect.", "Ok");
                    btnLogin.IsEnabled = true;
                }
                else if (login.errorCode == 0)
                {
                    Application.Current.Properties["id"] = 1;
                    await Navigation.PushAsync(new TabbedPage1());
                }
            }
            else
            {
                await DisplayAlert("Error!", "Something went wrong. please try again later!", "Ok");
                btnLogin.IsEnabled = true;
            }

        }

        /*protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");
                if (result)
                {

                }
            });

            return true;
        }*/
    }
}