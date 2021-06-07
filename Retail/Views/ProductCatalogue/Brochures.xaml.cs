using System;
using System.Collections.Generic;
using Retail.Controls;
using Retail.ViewModels.ProductCatalogue;
using Xamarin.Forms;

namespace Retail.Views.ProductCatalogue
{
    public partial class Brochures : ContentPage
    {
       
        public Brochures()
        {
            InitializeComponent();
            BindingContext = new BrochureViewModel(Navigation);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var popupImage = (Image)sender;            
            string currentUrl = popupImage.Source.ToString();
            Navigation.PushModalAsync(new ImagePopupView(currentUrl), true);
        }
    }
}
