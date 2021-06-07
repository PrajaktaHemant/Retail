using System;
using System.Collections.Generic;
using Retail.ViewModels.Dashboard;
using Xamarin.Forms;

namespace Retail.Views.Dashboard
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
            BindingContext = new NotificationsViewModel(Navigation);
        }
    }
}
