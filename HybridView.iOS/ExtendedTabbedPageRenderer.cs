using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using HybridView.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace HybridView.iOS
{
    class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            // Set Text Font for unselected tab states
            UITextAttributes normalTextAttributes = new UITextAttributes();
            normalTextAttributes.Font = UIFont.FromName("HelveticaNeue", 18.0F); // unselected
           
            UITabBarItem.Appearance.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            foreach (UIViewController viewController in base.ViewControllers)
            {
                UITextAttributes normalTextAttributes = new UITextAttributes();
                normalTextAttributes.Font = UIFont.FromName("HelveticaNeue", 18.0F); // unselected

                viewController.TabBarItem.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);
            }
            UITextAttributes selectedTextAttributes = new UITextAttributes();
            selectedTextAttributes.Font = UIFont.FromName("HelveticaNeue-Medium", 18.0F); // SELECTED
            base.SelectedViewController.TabBarItem.SetTitleTextAttributes(selectedTextAttributes, UIControlState.Normal);
            
        }

        public override UIViewController SelectedViewController
        {
            get
            {
                UITextAttributes selectedTextAttributes = new UITextAttributes();
                selectedTextAttributes.Font = UIFont.FromName("HelveticaNeue-Medium", 18.0F); // SELECTED
                if (base.SelectedViewController != null)
                {
                    base.SelectedViewController.TabBarItem.SetTitleTextAttributes(selectedTextAttributes, UIControlState.Normal);
                }
                return base.SelectedViewController;
            }
            set
            {
                base.SelectedViewController = value;

                foreach (UIViewController viewController in base.ViewControllers)
                {
                    UITextAttributes normalTextAttributes = new UITextAttributes();
                    normalTextAttributes.Font = UIFont.FromName("HelveticaNeue", 18.0F); // unselected

                    viewController.TabBarItem.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);
                }
            }
        }
    }
}