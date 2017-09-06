using System;
using System.IO;

namespace HybridView
{
    public interface IFilePath
    {
        string GetFilePath();
        string saveCapturedImageAndVideo(string filePath);
    }
}
