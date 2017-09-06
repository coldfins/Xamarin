using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace HybridView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraVideoPage : ContentPage
	{
        IMediaPicker _mediaPicker;
        public CameraVideoPage ()
		{
			InitializeComponent ();

            _mediaPicker = DependencyService.Get<IMediaPicker>();
        }

        private void Setup()
        {
            //DisplayAlert("Alert", "Setup1", "OK");
            if (_mediaPicker != null)
            {
               // DisplayAlert("Alert", "Setup2", "OK");
                return;
            }

            //DisplayAlert("Alert", "Setup3", "OK");
            var device = Resolver.Resolve<IDevice>();

            //DisplayAlert("Alert", "Setup4", "OK");
            ////RM: hack for working on windows phone? 
            _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
        }

        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        private async Task TakePicture(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "TakePicture", "OK");
            Setup();

            //Directory= Resolver.Resolve<IFilePath>().getStorageDirectory(),
            await this._mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Rear, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var s = t.Exception.InnerException.ToString();
                    DisplayAlert("MediaFile", "take Picture: : IsFaulted..." + s, "OK");
                }
                else if (t.IsCanceled)
                {
                    var canceled = true;
                    DisplayAlert("MediaFile", "take Picture: : canceled", "OK");
                }
                else
                {
                    var mediaFile = t.Result;
                    //DisplayAlert("MediaFile", "take Picture path OLD: : " + mediaFile.Path, "OK");

                    var newFilepath = Resolver.Resolve<IFilePath>().saveCapturedImageAndVideo(mediaFile.Path);
                    DisplayAlert("MediaFile", "take Picture: " + newFilepath, "OK");

                    //ImageSource ImageSource = ImageSource.FromStream(() => mediaFile.Source);
                    //imgSelectedImage.Source = ImageSource;

                    return mediaFile;
                }

                return null;
            }, _scheduler);
        }

        private async Task TakeVideo(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "TakeVideo", "OK");

            Setup();

            await this._mediaPicker.TakeVideoAsync(new VideoMediaStorageOptions { DefaultCamera = CameraDevice.Rear, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var s = t.Exception.InnerException.ToString();
                    DisplayAlert("MediaFile", "Video Picture: : IsFaulted..." + s, "OK");
                }
                else if (t.IsCanceled)
                {
                    var canceled = true;
                    DisplayAlert("MediaFile", "Video Picture: : canceled", "OK");
                }
                else
                {
                    var mediaFile = t.Result;

                    //ImageSource = ImageSource.FromStream(() => mediaFile.Source);
                    //DisplayAlert("MediaFile", "Video Picture: " + mediaFile.Path, "OK");

                    var newFilepath = Resolver.Resolve<IFilePath>().saveCapturedImageAndVideo(mediaFile.Path);
                    DisplayAlert("MediaFile", "Video Picture: : " + newFilepath, "OK");

                    return mediaFile;
                }

                return null;
            }, _scheduler);
        }

        private async Task SelectPicture(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "SelectPicture", "OK");

            Setup();
            await DisplayAlert("MediaFile", "Setup", "OK");
            //ImageSource = null;
            try
            {
                await DisplayAlert("MediaFile", "SelectPhotoAsync BEFORE", "OK");
                var mediaFile = await this._mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });

                await DisplayAlert("MediaFile", "Image Selected: " + mediaFile.Path, "OK");

                //ImageSource ImageSource = ImageSource.FromStream(() => mediaFile.Source);
                //imgSelectedImage.Source = ImageSource;
            }
            catch (Exception ex)
            {
                await DisplayAlert("MediaFile", "Error: " + ex.Message, "OK");
            }

        }

        private async Task SelectVideo(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "SelectVideo", "OK");

            Setup();

            string VideoInfo = "Selecting video";

            try
            {
                var mediaFile = await this._mediaPicker.SelectVideoAsync(new VideoMediaStorageOptions());

                if (mediaFile != null)
                {
                    VideoInfo = string.Format("Your video size {0} MB", ConvertBytesToMegabytes(mediaFile.Source.Length));
                }
                else
                {
                    VideoInfo = "No video was selected";
                }
                await DisplayAlert("MediaFile", "mediaFile: " + mediaFile.Path, "OK");
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("MediaFile", "Error: " + ex.Message, "OK");
                if (ex is TaskCanceledException)
                    VideoInfo = "Selecting video canceled";
            }
        }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}