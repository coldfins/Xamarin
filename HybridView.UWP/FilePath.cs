using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace HybridView.UWP
{
    public class FilePath : IFilePath
    {
        public string GetFilePath()
        {
            return Path.Combine("ms-appx-web:///", "..", "tmp", "HTML");
        }
        
        public string saveCapturedImageAndVideo(string filePath)
        {
            return null;
        }

    }
}