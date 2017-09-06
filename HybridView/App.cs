using Xamarin.Forms;

namespace HybridView
{
    public class App : Application
    {
        public const string baseUrl = "http://192.168.2.154:89/";

        public App()
        {
            //MainPage = Device.RuntimePlatform == Device.Windows ? new NavigationPage(new Page1()) : new NavigationPage(new HybridView());       
            //MainPage = new NavigationPage(new TabbedPage1());

            /*if (Application.Current.Properties.Keys.Contains("id") && Application.Current.Properties["id"] != null)
            {
                MainPage = new NavigationPage(new TabbedPage1());
            }
            else
            {
                MainPage = new NavigationPage(new LoginSettingsTabbedPage());
            }*/


            //MainPage = new NavigationPage(new Login());;
            MainPage = new NavigationPage(new Page1());



        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
