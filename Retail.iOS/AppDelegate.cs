using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using KeyboardOverlap.Forms.Plugin.iOSUnified;
using Retail.Hepler;
using Retail.ViewModels;
using UIKit;
using Xamarin.Forms;

namespace Retail.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        [System.Runtime.InteropServices.DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CommonAttribute.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            CommonAttribute.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;

            // NavigationController.NavigationBar.SetBackgroundImage(, UIBarMetrics.Default);
            // NavigationController.NavigationBar.Alpha = alpha;

            global::Xamarin.Forms.Forms.SetFlags("Brush_Experimental");
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            LoadApplication(new App());
            Rg.Plugins.Popup.Popup.Init();
            ImageCircleRenderer.Init();
            KeyboardOverlapRenderer.Init();

            MessagingCenter.Unsubscribe<BaseViewModel>(this, "Lang");
            MessagingCenter.Subscribe<BaseViewModel>(this, "Lang", (sender) =>
            {
                ObjCRuntime.Selector selector = new ObjCRuntime.Selector("setSemanticContentAttribute:");

                if (CommonAttribute.flowDirection == FlowDirection.LeftToRight)
                    AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceLeftToRight);
                else
                    AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceRightToLeft);

            });



            return base.FinishedLaunching(app, options);
        }
    }
}
