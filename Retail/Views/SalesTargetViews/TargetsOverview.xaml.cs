using System;
using System.Collections.Generic;
using Retail.ViewModels.SalesTarget;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Retail.Views.SalesTargetViews
{
    public partial class TargetsOverview : ContentPage
    {
        public TargetsOverview()
        {
            InitializeComponent();
            BindingContext = new TargetsOverviewViewModel(Navigation);
        }

        private async void txtCity_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Navigation.PushPopupAsync(new MultiselectStorePopup(2));
        }

        private async void txtStore_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Navigation.PushPopupAsync(new MultiselectStorePopup(1));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<object, string>(this, "SelectedStoreLists", (obj, s) => {
                txtStore.Text = s;
            });

            MessagingCenter.Subscribe<object, string>(this, "SelectedCityLists", (obj, s) => {
                txtCity.Text = s;
            });
        }
    }
}
