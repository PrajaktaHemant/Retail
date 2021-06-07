using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Retail.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Retail.Hepler;
using System.IO;
using Retail.DependencyServices;
using System.Collections.ObjectModel;
using Plugin.Media;

namespace Retail.ViewModels.MarketIntelligence
{
    public class MarketInsightsViewModel : BaseViewModel
    {
        public ObservableCollection<ImageSource> Media { get; set; }

        public MarketInsightsViewModel(INavigation navigation):base(navigation)
        {
            
        }

        public Command PickImageCommand
        {
            get
            {
                return new Command(async () =>
                {
                //string action = await Application.Current.MainPage.DisplayActionSheet("Photo Upload", "Cancel", null, "Take Photo", "Gallery");


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
                            ImageList.Add(ImageSource.FromStream(()=> stream));
                        }
                    }
                });
            }
        }

        public Command RecordVideoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                    {
                        await ErrorDisplayAlert("Camera not supported");
                        return;
                    }

                    var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                    {
                        Name = "video.mp4",
                        Directory = "DefaultVideos",
                        DesiredLength = new TimeSpan(300),
                        SaveToAlbum = true,
                        Quality = Plugin.Media.Abstractions.VideoQuality.Low
                    });

                    if (file == null)
                        return;

                    await ErrorDisplayAlert("Video Recorded");

                    file.Dispose();



                });
            }
        }

        public async Task<FileData> TakePhotoAsync()
        {
            try
            {
                GC.Collect();
                FileData fileData = new FileData();
                string action = await Application.Current.MainPage.DisplayActionSheet("Photo Upload", "Cancel", null, "Take Photo", "Gallery");
                FileResult photo = null;

                if (action != null && action == "Gallery")
                {
                    Photoaction = action;                    
                    var pickresult = await FilePicker.PickMultipleAsync(new PickOptions
                    {
                        FileTypes = FilePickerFileType.Images,
                        PickerTitle = "Pick Images"
                    });

                    if (pickresult != null)
                    {
                        Media = new ObservableCollection<ImageSource>();
                        foreach (var image in pickresult)
                        {
                            var stream = await image.OpenReadAsync();
                            Media.Add(ImageSource.FromStream(() => stream));
                        }
                    }
                }
                else if (action != null && action == "Take Photo")
                {
                    Photoaction = action;
                    if (!MediaPicker.IsCaptureSupported)
                    {
                        await ErrorDisplayAlert("Camera not supported");
                        return null;
                    }

                    photo = await MediaPicker.CapturePhotoAsync();
                }

                if (photo != null)
                {
                    Application.Current.Properties["Photoaction"] = Photoaction;
                    await Application.Current.SavePropertiesAsync();
                    return fileData = await LoadPhotoAsync(photo);

                    // Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                }
                return fileData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                return null;
            }
        }

        async Task<FileData> LoadPhotoAsync(FileResult photo)
        {
            // canceled
            try
            {
                FileData fileData = new FileData();

                if (photo == null)
                {
                    // PhotoPath = null;
                    return null;
                }

                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                fileData.FileType = photo.ContentType;
                if (Device.RuntimePlatform == Device.Android)
                {
                    using (var stream = await photo.OpenReadAsync())
                    {

                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);


                        string string64base = Extensions.ConvertToBase64(stream);
                        fileData.string64baseData = string64base;
                    }
                }
                else
                {
                    using (var stream = await photo.OpenReadAsync())
                    {
                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);

                        var originalImageByteArray = new Byte[(int)stream.Length];

                        stream.Seek(0, SeekOrigin.Begin);
                        stream.Read(originalImageByteArray, 0, (int)stream.Length);

                        var resizer = DependencyService.Get<IImageResizer>();
                        var resizedBytes = resizer.ResizeImage(originalImageByteArray, 400, 400);

                        string string64base = Convert.ToBase64String(resizedBytes);
                        fileData.string64baseData = string64base;
                    }




                }
                fileData.FileName = photo.FileName;

                return fileData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string Photoaction { get; set; }
    }
}

