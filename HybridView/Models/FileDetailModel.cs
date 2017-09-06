using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HybridView.Models
{
    class FileDetailModel
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Data { get; set; }

        private string imageType;// = string.Empty;
        public string ImageType
        {
            get
            {
                if (FileName.Contains(".doc") || FileName.Contains(".docx"))
                {
                    // Word document
                    return "doc.png";
                }
                else if (FileName.Contains(".pdf"))
                {
                    // PDF file
                    return "pdf.png";
                }
                else if (FileName.Contains(".ppt") || FileName.Contains(".pptx"))
                {
                    // Powerpoint file
                    return "ppt.png";
                }
                else if (FileName.Contains(".xml"))
                {
                    // ... XML file
                    return "xml.png";
                }
                else if (FileName.Contains(".xls") || FileName.Contains(".xlsx"))
                {
                    // Excel file
                    return "xls.png";
                }
                else if (FileName.Contains(".zip") || FileName.Contains(".rar"))
                {
                    // WAV audio file
                    return "zip.png";
                }
                else if (FileName.Contains(".rtf"))
                {
                    // RTF file
                    return "rtf.png";
                }
                else if (FileName.Contains(".wav") || FileName.Contains(".mp3"))
                {
                    // WAV audio file
                    return "wav.png";
                }
                else if (FileName.Contains(".gif"))
                {
                    // GIF file
                    return "gif.png";
                }
                else if (FileName.Contains(".jpg") || FileName.Contains(".jpeg") 
                    || FileName.Contains(".png"))
                {
                    // JPG file
                    return "jpg.png";
                }
                else if (FileName.Contains(".txt"))
                {
                    // Text file
                    return "txt.png";
                }
                else if (FileName.Contains(".3gp") || FileName.Contains(".mpg") 
                    || FileName.Contains(".mpeg") || FileName.Contains(".mpe") 
                    || FileName.Contains(".mp4") || FileName.Contains(".avi"))
                {
                    // Video files
                    return "gp.png";
                }
                else
                {
                    return "txt.png";
                }
                //return "ppt.png";
            }
            set
            {
                imageType = "txt.png";
            }
        }
    }
}
