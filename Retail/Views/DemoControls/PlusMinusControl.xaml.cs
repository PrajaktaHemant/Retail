using System;
using System.Collections.Generic;
using Retail.ViewModels.DemoControls;
using Xamarin.Forms;

namespace Retail.Views.DemoControls
{
    public partial class PlusMinusControl : ContentPage
    {
        public BarcodeViewModel viewModel { get; set; }

        public PlusMinusControl()
        {
            InitializeComponent();

            BindingContext = viewModel = new BarcodeViewModel(Navigation);

            int count = Convert.ToInt32(Application.Current.Properties["NoPersonEntry"]);

            for (int i = 0; i < count; i++)
            {
            //    DynamicStack.Children.Add
            //    ( new StackLayout()
            //    {
            //        Children =
            //        {
            //            new Entry() {StyleId=""}
            //        }
            //    });
            }

        }

        void ImageEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //await viewModel.ValidateModelNumber();
        }
    }
}
