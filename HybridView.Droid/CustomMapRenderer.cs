using HybridView.Droid;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomMapRenderer))]
namespace HybridView.Droid
{
    class CustomMapRenderer : NavigationPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            //var bar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRenderer)
            //.GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
            //.GetValue(this);


            //var bar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRend‌​erer).GetField("_toolbar", BindingFlags.NonPublic).GetValue(this);
            //bar.SetLogo(Resource.Drawable.icon);
            //bar.SetNavigationIcon(Resource.Drawable.setting);
        }
    }
}