using System;
using System.Globalization;
using Retail.Views;
using Retail.Views.Dashboard;
using Retail.Views.SalesTargetViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Retail.Hepler;
using System.Threading.Tasks;
using Extensions = Retail.Hepler.Extensions;
using Retail.Infrastructure.RequestModels;
using Retail.Infrastructure.ServiceLayer;
using Retail.Infrastructure.Models;
using Retail.Infrastructure.ResponseModels;
using Retail.Infrastructure.Enums;
using Retail.Views.Account;

namespace Retail
{
    public partial class App : Application
    {
        public App()
        {
            

            LocalizationResourceManager.Instance.SetCulture(CultureInfo.GetCultureInfo("en-US"));

            InitializeComponent();
            //AppCenter.Start("android=8e84bf91-f0b4-41d4-b65d-a0cb50f1eda8;" +
            //      "ios=65f626e5-6898-4061-930b-eedcbad53515",
            //      typeof(Analytics), typeof(Crashes));

        }

        public async Task<bool> LoginPage()
        {
            var languages = Extensions.Getlanguages();
            CommonAttribute.selectedLang = languages[0];
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.email = Current.Properties["email"].ToString();
            loginRequest.username = Current.Properties["email"].ToString();
            loginRequest.password = Current.Properties["password"].ToString();
            UserManagementSL userManagementSL = new UserManagementSL();
            ReceiveContext<PersonLoginResponse> receiveContext = await userManagementSL.ValidateUser(loginRequest);
            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
            {
                if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Customer))
                {
                    CommonAttribute.CustomeProfile = receiveContext.data;
                    return true;
                    // Application.Current.MainPage = new DashBoadMasterPage();
                }
            }
            return false;

        }

        protected async override void OnStart()
        {
            //MainPage = new DashboardMenuPage();
            if (Current.Properties.ContainsKey("email") && Current.Properties.ContainsKey("password"))
            {
                try
                {

                    bool res = await LoginPage();
                    if (res)
                    {
                        MainPage = new DashboardMasterPage();
                    }
                    else
                    {
                        var navigation = new NavigationPage(new LoginPage());

                        navigation.BarBackgroundColor = Color.FromHex("#2D3EE1");
                        MainPage = navigation;// new NavigationPage(new ServiceManualModelPage());
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                var navigation = new NavigationPage(new LoginPage());

                navigation.BarBackgroundColor = Color.FromHex("#2D3EE1");
                MainPage = navigation;// new TechMasterPage(); //navigation;
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
