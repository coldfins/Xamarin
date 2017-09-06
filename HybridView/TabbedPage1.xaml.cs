using System;
using System.Net.Http;
using System.Threading.Tasks;
using CustomRenderer.Model;
using Newtonsoft.Json;
using XLabs.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HybridView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var html = await RenderHtmlAsync();
                Children.Add(new HybridView("Test1", html));
                Children.Add(new HybridView("Test2", html));
                Children.Add(new HybridView("Test3", html));
            });
            Title = "Hybridview";
            
            Icon = "icon.png";
            //var Icon = String.Format("{0}{1}.png", Device.OnPlatform("Icons/", "", "Assets/Icons"), "icon.png");
            ToolbarItems.Add(new ToolbarItem() { Icon = "setting.png", Priority = 0 });
            ToolbarItems.Add(new ToolbarItem() { Icon = "logout.png", Priority = 0 });
            //this.ToolbarItems.Add(new ToolbarItem() { Text = title });
            //this.ToolbarItems.Add(new ToolbarItem() { Text = "logout" });
            //ToolbarItems.Add(new ToolbarItem("Filter", "icon.png", async () => { var page = new ContentPage(); var result = await page.DisplayAlert("Title", "Message", "Accept", "Cancel"); Debug.WriteLine("success: {0}", result); }));
        }

        private static async Task<string> RenderHtmlAsync()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("http://employeemobileappservice.azurewebsites.net/api/employeeapi?empId=2");
                var response = await client.GetAsync(uri);
                var uiData = JsonConvert.DeserializeObject<EmployeeForm>(await response.Content.ReadAsStringAsync());
                return uiData.Data;
                //hybrid.CallJsFunction($"loadHtml('{uiData.Data}')");
            }
        }
            
    }
}