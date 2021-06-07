using System;
using System.Collections.Generic;
using Retail.ViewModels.InventoryStock;
using Xamarin.Forms;

namespace Retail.Views.InventoryStock
{
    public partial class AddInventoryStock : ContentPage
    {
        ADdInventoryViewModel viewModel { get; set; }
        List<StoreList> StoresList { get; set; }
        public AddInventoryStock(string ModelNo)
        {
            InitializeComponent();
            BindingContext = viewModel = new ADdInventoryViewModel(Navigation);
            txtModelNo.Text = ModelNo;
            StoresList = new List<StoreList>();
            StoresList.Add(new StoreList { StoreName = "Panasonic Store LULU" });
            StoresList.Add(new StoreList { StoreName = "Panasonic Store, Sharjah" });
            StoresList.Add(new StoreList { StoreName = "Panasonic Store, Dubai" });
            StoresList.Add(new StoreList { StoreName = "Panasonic Store, SAFARI" });

            StoreDropdown.ItemsSource = StoresList;
            StoreDropdown.SelectedItem = StoresList[0];
        }

        void rbInventoryStock_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if(rbInventoryStock.IsChecked)
            {
                txtQty.IsVisible = true;
                lblQty.IsVisible = true;
                viewModel.IsQtyListVisible = true;
            }
            else
            {
                txtQty.IsVisible = false;
                lblQty.IsVisible = false;
                viewModel.IsQtyListVisible = false;
            }
        }

        void rbOutofStock_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (rbOutofStock.IsChecked)
            {
                txtQty.IsVisible = false;
                lblQty.IsVisible = false;
                viewModel.IsQtyListVisible = false;
            }
            else
            {
                txtQty.IsVisible = true;
                lblQty.IsVisible = true;
                viewModel.IsQtyListVisible = true;
            }

        }

        void TitledDateTimePicker_ItemTapped(System.Object sender, System.EventArgs e)
        {
            var dp = sender as DatePicker;
            viewModel.SelectedDate = dp.Date;
        }

        void StoreDropdown_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
        }
    }
}
