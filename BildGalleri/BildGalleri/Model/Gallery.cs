using System;
using System.Collections.Generic;
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


    }
}