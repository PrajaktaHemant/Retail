using System;
using Retail.DependencyServices;
using Retail.Hepler;
using Xamarin.Forms;

namespace Retail.ViewModels.ImagePopUp
{
    public class ImagePopupViewModel : BaseViewModel
    {
        string downloadimage { get; set; }
        public ImagePopupViewModel(INavigation navigation , string _ImageURL) : base(navigation)
        {
            downloadimage = _ImageURL;
        }

        public Command DownloadImageCommad
        {
            get
            {
                return new Command<string>(async (item) =>
                {
                    try
                    {
                        //IsBusy = true;
                     
                            string imgUrl = downloadimage;
                            byte[] bytes = await Extensions.DownloadImageAsync(imgUrl);
                            if (bytes != null)
                            {
                                var hud = DependencyService.Get<IMediaService>();
                                if (hud != null)
                                {
                                    string filename = System.IO.Path.GetFileName(imgUrl);

                                    hud.SaveImageFromByte(bytes, filename);
                                    await DisplayAlert("Success", "Warranty card downloaded.");
                                }

                            }
                            else
                            {
                                await ErrorDisplayAlert("Your warranty card not yet ready.");
                            }
                        
                        //IsBusy = false;

                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                });
            }
        }
    }
}

