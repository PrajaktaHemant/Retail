using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Retail.Hepler;
using Retail.Infrastructure.Hepler;
using Retail.Models;
using Retail.Views;
using Retail.Views.Attendance;
using Retail.Views.Dashboard;
using Retail.Views.MyVisits;
using Retail.Views.SalesTargetViews;
using Xamarin.Forms;

namespace Retail.ViewModels.Dashboard
{
    public class DashboardMasterPageViewModel : BaseViewModel
    {
        public ICommand SalesTargetCommand { get; set; }
        public ICommand MyVisitsCommand { get; set; }
        public ICommand SurveysCommand { get; set; }
        public ICommand StoreLocatorCommand { get; set; }
        public ICommand AttendanceCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public DashboardMasterPageViewModel(INavigation navigation) : base(navigation)
        {
            //IsBusy = false;

            SalesTargetCommand = new Command(() =>
            {
                Navigation.PushAsync(new MonthlyTargetView());
            });

            MyVisitsCommand = new Command(() =>
            {
                Navigation.PushAsync(new PlannedVisitsView());
            });

            SurveysCommand = new Command(() =>
            {
                Navigation.PushAsync(new StoreSelection());
            });

            StoreLocatorCommand = new Command(() =>
            {
                Navigation.PushAsync(new AttendanceSummary());
            });

            AttendanceCommand = new Command(() =>
            {
                Navigation.PushAsync(new SampleCalender());
            });

            LogoutCommand = new Command(() =>
            {
                Navigation.PushAsync(new SalesDataReturnEntry());
            });

            Device.BeginInvokeOnMainThread(async () => {

                CommonAttribute.UserLocation = await Extensions.GetGeolocation();
                if (CommonAttribute.UserLocation == null)
                {
                    await ErrorDisplayAlert("Your gps location is not accurate.");
                }
            });

            if (BannersData == null)
                BannersData = new ObservableCollection<BannerData>();

            BannersData.Add(new BannerData() { UserProfile = true, id = 1, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/1.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 2, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/2.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 3, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/3.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 4, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/4.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 5, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/5.jpg" });
        }

        private ObservableCollection<BannerData> _BannersData;
        public ObservableCollection<BannerData> BannersData
        {
            get { return _BannersData; }
            set
            {
                _BannersData = value;
                OnPropertyChanged("BannersData");
            }
        }
    }
}

