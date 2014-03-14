using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BildGalleri.Model
{
    public class Gallery
    {
        private static readonly Regex ApprovedExtensions;

        private static readonly string PhysicalUploadedImagesPath;

        static Gallery()
        {
            ApprovedExtensions = new Regex(@"^.*\.(gif|jpg|png)$");
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Images");
        }

        public static IEnumerable<string> GetImageNames()
        {
            var di = new DirectoryInfo(PhysicalUploadedImagesPath);
            var imageList = new List<string>(20);
            foreach(FileInfo fi in di.GetFiles())
            {
                if(ApprovedExtensions.IsMatch(fi.Extension))
                {
                    imageList.Add(fi.Name);
                }
            }
            imageList.Sort();

            return imageList;
        }

        private static bool IsValidImage(Image image)
        {
            return (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid);
        }

        public static bool ImageExists(string name)
        {
            return GetImageNames().Contains(name); // Returnerar true om minst en fil hittas med samma namn som den som efterfrågas.
        }

        public static string SaveImage(Stream stream, string fileName)
        {
            var image = Image.FromStream(stream);

            if(!IsValidImage(image))
            {
                throw new BadImageFormatException();
            }

            if(ImageExists(fileName))
            {
                var i = 0;
                var name = Path.GetFileNameWithoutExtension(fileName);
                var extension = Path.GetExtension(fileName);

                do
                {
                    fileName = String.Format("{0} ({1}){2}", name, ++i, extension);
                } while(ImageExists(fileName));
            }

            image.Save(Path.Combine(PhysicalUploadedImagesPath, fileName));

            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
            thumbnail.Save(Path.Combine(PhysicalUploadedImagesPath, "Thumbs", fileName));

            return fileName;
        }
    }
}