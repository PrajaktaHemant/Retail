using System;
using AndroidHUD;
using Plugin.CurrentActivity;
using Retail.DependencyServices;
using Retail.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(EWProgress))]
namespace Retail.Droid.DependencyServices
{
    public class EWProgress : IEWProgress
    {
        public void Dismiss()
        {
            AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
        }

        public void Show()
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, "Please Wait", 1);
        }

        public void Show(string message)
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, message, 1);
        }
    }
}
