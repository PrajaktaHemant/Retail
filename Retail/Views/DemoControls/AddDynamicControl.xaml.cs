using System;
using System.Collections.Generic;
using System.IO;
using Retail.ViewModels.DemoControls;
using Rg.Plugins.Popup.Extensions;
using SignaturePad.Forms;
using Xamarin.Forms;

namespace Retail.Views.DemoControls
{
    public partial class AddDynamicControl : ContentPage
    {
        BarcodeViewModel viewModel { get; set; }
        public AddDynamicControl()
        {
            InitializeComponent();
            BindingContext = viewModel = new BarcodeViewModel(Navigation);
            //viewModel.SignaturePadViewItem += ViewModel_SignaturePadViewItem;
        }

        //private async void ViewModel_SignaturePadViewItem(object sender, EventArgs e)
        //{
        //    if (!Signature.IsBlank)
        //    {

        //        var img = await Signature.GetImageStreamAsync(SignatureImageFormat.Png);
        //        var signatureMemoryStream = new MemoryStream();
        //        img.CopyTo(signatureMemoryStream);
        //        byte[] data = signatureMemoryStream.ToArray();
        //        viewModel.signatureBase64string = Convert.ToBase64String(data);
        //    }
        //}

        void Create_Clicked_1(System.Object sender, System.EventArgs e)
        {
            //int count = Convert.ToInt32(Application.Current.Properties["NoPersonEntry"]);
            List<string> ListModelNumbers=new List<string> ();

            //for (int i = 0; i < 4; i++)
            //{
            //    DynamicStack.Children.Add
            //    (new StackLayout()
            //    {
            //        Children =
            //        {
            //            new Label (){TextColor = Color.Black, Text = TxtModelNumber.Text, WidthRequest = 100,StyleId="FnameLabel"+i },
            //            new Button(){Text="Delete", StyleId="FnameLabel"+i, }
            //        }
            //    });
            //}
        }

        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            await Navigation.PushPopupAsync(new Page2());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<object, string>(this, "Hi", (obj, s) => {
                entry.Text = s;
            });
        }
    }
}
