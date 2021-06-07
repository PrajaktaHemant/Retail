using System;
using System.Collections.Generic;
using Retail.Hepler;
using Retail.ViewModels.Dashboard;
using Xamarin.Forms;

namespace Retail.Views.Dashboard
{
    public partial class DashboardMenuPage : Shell
    {
        public DashboardMenuPageViewModel viewModel { get; set; }

        public DashboardMenuPage()
        {
            Device.SetFlags(new[] {
                "Brush_Experimental",
            });
            InitializeComponent();

            BindingContext = viewModel = new DashboardMenuPageViewModel(Navigation);

            //if (CommonAttribute.CustomeProfile.ProfilePictureFileInfo != null)
            //{
            //    if (Application.Current.Properties.ContainsKey("Photoaction") && Application.Current.Properties["Photoaction"] != null)
            //    {
            //        if (Application.Current.Properties["Photoaction"].ToString() == "Take Photo")
            //            imgUserPic.Rotation = 90;

            //    }

            //    imgUserPic.Source = CommonAttribute.ImageBaseUrl + CommonAttribute.CustomeProfile.ProfilePictureFileInfo.Path;
            //}
            //else
                imgUserPic.Source = "defultuser";

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void BtnMenu_Clicked(object sender, EventArgs e)
        {
            if (FlyoutIsPresented)
                FlyoutIsPresented = false;

            FlyoutIsPresented = true;
        }
        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {

        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }
    }
}
