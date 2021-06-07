using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Retail.Controls;
using Retail.ViewModels.SalesTarget;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Retail.Views.SalesTargetViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCategoryPopupView 
    {
        ProductCategoryPopupViewModel viewModel { get; set; }
        List<ProductCategory> ProductCategoryList { get; set; }
        public ProductCategoryPopupView(int flag)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductCategoryPopupViewModel(Navigation, flag);

            ProductCategoryList = new List<ProductCategory>();
            ProductCategoryList.Add(new ProductCategory { ProductCategoryName = "Washing Machine" });
            ProductCategoryList.Add(new ProductCategory { ProductCategoryName = "Dryer" });
            ProductCategoryList.Add(new ProductCategory { ProductCategoryName = "Refrigerator" });
            ProductCategoryList.Add(new ProductCategory { ProductCategoryName = "Microwave" });

            DropdownProductCategory.ItemsSource = ProductCategoryList;
            DropdownProductCategory.SelectedItem = ProductCategoryList[0];
            DropdownProductSubCategory.ItemsSource = ProductCategoryList;
            DropdownProductSubCategory.SelectedItem = ProductCategoryList[0];

        }

        private async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }

        void DropdownProductCategory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Xamarin.Forms.Picker)sender;
            int selectedIndex = picker.SelectedIndex;
        }

        void DropdownProductSubCategory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Xamarin.Forms.Picker)sender;
            int selectedIndex = picker.SelectedIndex;
        }

    }
}
