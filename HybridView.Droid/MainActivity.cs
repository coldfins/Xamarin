using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Platform.Device;

namespace HybridView.Droid
{
    [Activity(Label = "HybridView", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SetIoC();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void SetIoC()
        {
            var resolverContainer = new SimpleContainer();

            resolverContainer.Register(t => AndroidDevice.CurrentDevice);
            resolverContainer.Register<IJsonSerializer, XLabs.Serialization.JsonNET.JsonSerializer>();
            resolverContainer.Register<IDependencyContainer>(resolverContainer);
            resolverContainer.Register<IFilePath>(t => new FilePath());

            Resolver.ResetResolver();
            Resolver.SetResolver(resolverContainer.GetResolver());

        }
    }
}

