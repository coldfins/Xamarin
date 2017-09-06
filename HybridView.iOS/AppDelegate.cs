
using System;
using System.Diagnostics;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Serialization;

namespace HybridView.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    [assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]

    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SetIoC();

            HybridWebViewRenderer.CopyBundleDirectory("HTML");

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            var file = Resolver.Resolve<IFilePath>().GetFilePath();
            Debug.WriteLine("call from OnAppearing: " + file + "/" + "index.html");
            return base.FinishedLaunching(app, options);
        }

        private void SetIoC()
        {
            var resolverContainer = new SimpleContainer();

            resolverContainer.Register(t => AppleDevice.CurrentDevice);
            resolverContainer.Register<IJsonSerializer, XLabs.Serialization.JsonNET.JsonSerializer>();
            resolverContainer.Register<IDependencyContainer>(resolverContainer);
            resolverContainer.Register<IFilePath>(t => new FilePath());

            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}
