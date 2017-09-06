using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Ioc;

namespace HybridView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async Task BtnGetData_OnClicked(object sender, EventArgs e)
        {

            Login filePage = new Login();
            await Navigation.PushAsync(filePage, false);

            /*await ShowPopup().ContinueWith(async (info) =>
             {
                 await DisplayAlert("Alert", "Get Data is called", "Ok");
             });*/
        }

        private async Task ShowPopup()
        {
            //Create `ContentPage` with padding and transparent background
            var loginPage = new ContentPage
            {
                BackgroundColor = Color.White,// Color.FromHex("3d8ee9"),
                Padding = new Thickness(0, 0, 0, 0)
            };

            var login = new Login();
            // Create Children

            //Create desired layout to be a content of your popup page. 
            var contentLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                //Children = login
            };

            //set popup page content:
            loginPage.Content = login.Content;

            //Show Popup
            await Navigation.PushAsync(loginPage, false);
        }

        private void BtnCamera_OnClicked(object sender, EventArgs e)
        {
            //DisplayAlert("Alert", "BtnCamera_OnClicked", "Ok");

            CameraVideoPage cameraPage = new CameraVideoPage();
            Navigation.PushAsync(cameraPage, false);
        }
    }
}