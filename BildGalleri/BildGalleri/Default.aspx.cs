using BildGalleri.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BildGalleri
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<string> Repeater1_GetData()
        {
            return Gallery.GetImageNames();
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    try
                    {
                        Gallery.SaveImage(file.InputStream, file.FileName);
                    }

                    catch (BadImageFormatException)
                    {
                        string errorMessage = "Felaktigt filformat";
                    }

                    catch
                    {
                        string errorMessage = "Något sket sig";
                    }
                }
            }
        }
    }
}