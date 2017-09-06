using Android.App;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.NavigationPage), typeof(NavigationPageRenderer))]
namespace HybridView.Droid
{
    public class NavigationPageRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            var actionBar = ((Activity)Context).ActionBar;
            //actionBar.SetIcon(Resource.Drawable.icon);

            actionBar.SetDisplayHomeAsUpEnabled(true);
            actionBar.SetDisplayShowHomeEnabled(true);
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.icon);

        }
    }
}