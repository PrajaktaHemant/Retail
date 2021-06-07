using System;
using System.Collections.Generic;
using System.IO;
using DLToolkit.Forms.Controls;
using Retail.DependencyServices;
using Retail.Models;
using Retail.ViewModels.DemoControls;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Retail.Views.DemoControls
{
    public partial class TakePhotoAndDisplay : ContentPage
    {
        TakePhotoAndDisplayViewModel viewModel;

        private IMultiMediaPickerService multiMediaPickerService;
        [Obsolete]
        public TakePhotoAndDisplay()
        {
            InitializeComponent();
            //BindingContext = viewModel = new TakePhotoAndDisplayViewModel();
            FlowListView.Init();
            multiMediaPickerService = DependencyService.Get<IMultiMediaPickerService>();
            //BindingContext = new TakePhotoAndDisplayViewModel(multiMediaPickerService);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //viewModel.IsBusy = true;
            //Device.BeginInvokeOnMainThread(async () =>
            //{

            //    FileData fileData = await viewModel.TakePhotoAsync();
            //    if (!string.IsNullOrEmpty(fileData?.string64baseData))
            //    {

            //        viewModel.UserPic = ImageSource.FromStream(
            //   () => new MemoryStream(Convert.FromBase64String(fileData.string64baseData)));
            //        DisplayImages.ItemsSource = viewModel.Media;

            //        //MessagingCenter.Send<TakePhotoAndDisplayViewModel, ImageSource>(this, "UserPhoto", viewModel.UserPic);
            //        //if (viewModel.Photoaction != "Gallery")
            //        //    DisplayPhoto.Rotation = 90;
            //        //else
            //        //    DisplayPhoto.Rotation = 0;
            //        //await viewModel.SaveUserPic(fileData);
            //    }
            //    viewModel.IsBusy = false;


            //});


        }

       
        async void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            var pickresult = await FilePicker.PickMultipleAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick Images"
            });

            if (pickresult != null)
            {
                var ImageList = new List<ImageSource>();
                foreach (var image in pickresult)
                {
                    var stream = await image.OpenReadAsync();
                    ImageList.Add(ImageSource.FromStream(() => stream));
                }

                DisplayImageList.ItemsSource = ImageList;
            }
        }
    }
}
