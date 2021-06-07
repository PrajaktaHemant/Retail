using System;
using System.Collections.Generic;
using Retail.ViewModels.Dashboard;
using Xamarin.Forms;

namespace Retail.Views.Dashboard
{
    public partial class DashboardMasterPage : ContentPage
    {
        
        public ToolbarItem toolbarItem { get; set; }

        public DashboardMasterPage()
        {
            InitializeComponent();
           
            BindingContext = new DashboardMasterPageViewModel(Navigation);
            toolbarItem = new ToolbarItem
            {
                Text = "dashbord",
                IconImageSource = ImageSource.FromFile("info.png"),
                Order = ToolbarItemOrder.Primary,
                //Command = dashboardMasterPageViewModel.UserNotificationsCommand,
                Priority = 0
            };

            this.ToolbarItems.Add(toolbarItem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void BtnMenu_Clicked(object sender, EventArgs e)
        {            
            Shell.Current.FlyoutIsPresented = true;
        }


    }
}
