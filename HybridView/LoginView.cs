using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using System.Threading.Tasks;
using XLabs.Platform.Services;

namespace HybridView
{
    public class LoginView : ContentPage
    {
        private readonly string _fileName = "login.html";
        private HybridWebView _hybrid;
        
        public LoginView()
        {
            //_formTemplates = formTemplates;
            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Azure
            };

            _hybrid = new HybridWebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Azure
            };

            RegisterCallBacks();
            stack.Children.Add(_hybrid);
            Content = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,
                Content = stack
            };
            LoadSource();
            //_hybrid.LoadFinished += (s, e) => { LoadHtml(); };
            BackgroundColor = Color.FromHex("#3C444D");
            //NavigationPage.SetHasBackButton(this, false);
            //NavigationPage.SetHasNavigationBar(this, false);
            //Icon = FontAwesome.;
            Padding = new Thickness(0, -1000, 0, 200);
        }

        private void LoadSource(int count = 0)
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var filePath = Resolver.Resolve<IFilePath>().GetFilePath();
                    _hybrid.Source = Path.Combine(filePath, _fileName);
                });
                Debug.WriteLine("LoadSource");
            }
            catch (Exception e)
            {
                if (count < 5)
                {
                    count++;
                    LoadSource(count);
                }
                else
                {
                    DisplayAlert("Alert", "Could Load file page. Please try again.", "Ok");
                    Debug.WriteLine($"{e.Message}");
                }
            }
        }


        private void RegisterCallBacks()
        {
            /*_hybrid.RegisterCallback("loginApp",
                args =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var data = args;
                        var login = JsonConvert.DeserializeObject<LoginVM>(data);
                        if (login.UserName == "test" && login.Password == "test")
                        {
                            Navigation.PushAsync(new Page1());
                        }
                    });
                    //var dataUnits = data.Split('&');
                    //var context = new Dictionary<string, string>();
                    //foreach (var dUnit in dataUnits)
                    //    context.Add(dUnit.Split('=')[0], dUnit.Split('=')[1]);
                    //var uiDoc = new UIDoc();
                    //var html = uiDoc.Render(context);

                    //Device.BeginInvokeOnMainThread(() => { _hybrid.CallJsFunction("invokeFromCS", html); });
                    // Device.BeginInvokeOnMainThread(() => { DisplayAlert("Alert", "Native", "cancel"); }); });
                });*/


            _hybrid.RegisterCallback("loginApp",
                args =>
                {
                    var data = args;
                    var login = JsonConvert.DeserializeObject<LoginVM>(data);

                    if (login.UserName == "test" && login.Password == "test")
                    {
                        //await Navigation.PushAsync(new Page1());
                        Navigation.PushAsync(new Page1());
                    }
                    /*Device.BeginInvokeOnMainThread(async () =>
                    {
                        var data = args;
                        var login = JsonConvert.DeserializeObject<LoginVM>(data);

                        if (login.UserName == "test" && login.Password == "test")
                        {
                            await Navigate();
                        }
                    });*/
                });

        }

        //private async Task Navigate()
        //{
        //    await Navigation.PushModalAsync(new Page1());
        //}

    }
}