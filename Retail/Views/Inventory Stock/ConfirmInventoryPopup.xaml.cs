using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Retail.ViewModels.InventoryStock;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Retail.Views.InventoryStock
{
    public partial class ConfirmInventoryPopup 
    {
        ConfirmInventoryPopupVewModel viewModel { get; set; }
        public ConfirmInventoryPopup()
        {
            InitializeComponent();
            BindingContext = viewModel = new ConfirmInventoryPopupVewModel(Navigation); 
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}


public class InventoryData
{
    public string ProductCategoryName { get; set; }
    public string ModelNo { get; set; }
    public string Qty { get; set; }
}