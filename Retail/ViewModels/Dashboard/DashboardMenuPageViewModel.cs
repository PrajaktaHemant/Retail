using System;
using Retail.DependencyServices;
using Retail.Views.Dashboard;
using Retail.Views.DemoControls;
using Retail.Views.InventoryStock;
using Retail.Views.MarketIntelligence;
using Retail.Views.ProductCatalogue;
using Retail.Views.SalesTargetViews;
using Xamarin.Forms;

namespace Retail.ViewModels.Dashboard
{
    public class DashboardMenuPageViewModel : BaseViewModel
    {
        
        public DashboardMenuPageViewModel(INavigation navigation) : base(navigation)
        {
            //Content = new Label { Text = "Hello ContentView" };
        }

        public Command MonthlyTargetCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new SalesDataEntry(null));
                });
            }
        }

        public Command ExpandableListViewCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new InventoryStockDetails());
                });
            }
        }

        public Command ViewBrochureCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new Brochures());
                });
            }
        }

        [Obsolete]
        public Command DisplayPhotoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new AddInventoryStock(null));
                });
            }
        }

        public Command QRCodeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new AddDynamicControl());
                });
            }
        }

        public Command MarketIntelCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new MarketIntelligenceView());
                });
            }
        }

        public Command TargetOverviewCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new TargetsOverview());
                });
            }
        }
    }
}

