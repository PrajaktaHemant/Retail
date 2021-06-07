using System;
using System.Collections.Generic;
using Retail.ViewModels.MyVisits;
using Xamarin.Forms;

namespace Retail.Views.MyVisits
{
    public partial class StoreSelection : ContentPage
    {
        public StoreSelection()
        {
            InitializeComponent();
            BindingContext = new StoreSelectionViewModel(Navigation);
        }

        void SearchStore_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
        }

        void SearchStore_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
        }
    }
}
