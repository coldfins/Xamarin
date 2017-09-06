using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using CustomRenderer.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Serialization;

namespace HybridView
{
    public class HybridView : ContentPage
    {
        private readonly string _html;
        private const string fileName = "index.html";
        private readonly HybridWebView hybrid;

        public HybridView(string title, string html)
        {
            _html = html;
            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

            hybrid = new HybridWebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            var injectJsButton = new Button
            {
                Text = "Inject JavaScript",
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            injectJsButton.Clicked += InjectJsButton_Clicked;

            var callCsFunctionButton = new Button
            {
                Text = "CallJsFunction",
                BackgroundColor = Color.Purple,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var btnLogout = new Button
            {
                Text = "Logout",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            btnLogout.Clicked += logout;

            callCsFunctionButton.Clicked += CallCsFunctionButton_Clicked;

            RegisterCallBacks();
            stack.Children.Add(injectJsButton);
            stack.Children.Add(callCsFunctionButton);
            stack.Children.Add(btnLogout);
            stack.Children.Add(hybrid);
            var scrollView = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,

                Content = stack
            };
            Content = scrollView;

            var filePath = Resolver.Resolve<IFilePath>().GetFilePath();
            hybrid.Source = filePath + "/" + fileName;
            hybrid.LoadFinished += loadHtml;

            Title = title; 
        }

        private void logout(object sender, EventArgs e)
        {
            Application.Current.Properties["id"] = null;
            Navigation.PushAsync(new LoginSettingsTabbedPage());
        }

        private void loadHtml(object sender, EventArgs e)
        {
            hybrid.CallJsFunction($"loadHtml", _html);
        }

        private void RegisterCallBacks()
        {
            hybrid.RegisterCallback("callNative",
                args =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        hybrid.CallJsFunction($"loadHtml", _html);
                        DisplayAlert("Alert", "Native", "cancel");
                    });
                });

            hybrid.RegisterNativeFunction("callNativeFunc", args =>
            {
                Device.BeginInvokeOnMainThread(() => { DisplayAlert("Alert", "NativeFunc", "cancel"); });
                return new object[] { args };
            });

            hybrid.RegisterCallback("invokeCSharpAction", s =>
            {
                var serializer = Resolver.Resolve<IJsonSerializer>();

                var o = serializer.Deserialize<List<SendObject>>(s);

                foreach (var context in o)
                    DisplayAlert("Object", $"JavaScript sent x: {context.name}, y: {context.value}",
                        "OK");
            });

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //var filePath = Resolver.Resolve<IFilePath>().GetFilePath();
            //Debug.WriteLine("call from OnAppearing: " + filePath + "/" + fileName);
            //hybrid.Source = filePath + "/" + fileName;
            //hybrid.LoadFromContent(filePath + "/" + fileName);
            //hybrid.CallJsFunction($"loadHtml", _html); // Commented on 2017/08/09 created new method loadHtml
        }

        protected override bool OnBackButtonPressed()
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
        }



        private async void CallCsFunctionButton_Clicked(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("http://employeemobileappservice.azurewebsites.net/api/employeeapi?empId=2");
                var response = await client.GetAsync(uri);
                var uiData = JsonConvert.DeserializeObject<EmployeeForm>(await response.Content.ReadAsStringAsync());
                hybrid.CallJsFunction($"loadHtml('{uiData.Data}')");
                hybrid.InjectJavaScript("alert(\"Hello world!\");");
                //hybrid.CallJsFunction($"loadHtml", uiData.Data);
            }
        }

        private void InjectJsButton_Clicked(object sender, EventArgs e)
        {
            hybrid.InjectJavaScript("alert(\"Hello world!\");");
        }
    }

    public class SendObject
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}