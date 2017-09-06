using Foundation;
using QuickLook;
using System;
using System.IO;
using UIKit;
using Xamarin.Forms;

namespace HybridView.iOS
{
    public class FilePath : IFilePath
    {
        public string GetFilePath()
        {
            var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(docs, "..", "tmp", "HTML");
        }

        public string saveCapturedImageAndVideo(string filePath)
        {
            Byte[] byteArray = File.ReadAllBytes(filePath);

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var directoryname = Path.Combine(documents, "HybridView");
            Directory.CreateDirectory(directoryname);

            var newfilePath = Path.Combine(directoryname, Path.GetFileName(filePath));

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