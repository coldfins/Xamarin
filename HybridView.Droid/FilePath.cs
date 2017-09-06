using System.IO;
using System;
using System.Security.Permissions;
using Android;
using Android.OS;
using Android.Support.V4.Content;
using Android.Content.PM;
using Android.Support.V4.App;
using Xamarin.Forms;
using Android.App;
using Android.Content;

namespace HybridView.Droid
{
    public class FilePath : IFilePath
    {
        public string GetFilePath()
        {
            return "file:///android_asset";
        }
      
        public string saveCapturedImageAndVideo(string filePath) {
            Byte[] byteArray = File.ReadAllBytes(filePath);

            var documents = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/HybridView/";
            var newfilePath = Path.Combine(documents, Path.GetFileName(filePath));

            if (File.Exists(newfilePath))
            {
                File.Delete(newfilePath);
            }

            if (!File.Exists(newfilePath))
            {
                File.WriteAllBytes(newfilePath, byteArray);
            }

            return newfilePath;
        }
    }
}