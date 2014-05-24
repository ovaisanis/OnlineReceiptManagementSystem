using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ReceiptManagement.RESTfulAPI.Utilities
{
    public class HelperMethods
    {
        /// <summary>
        /// Image Saving code for image file Uploader
        /// </summary>
        public static string SaveImage(HttpPostedFile postedFile, string imagePath)
        {
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string strPath = HttpContext.Current.Server.MapPath(imagePath);

                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);

                string fileExtension = Path.GetExtension(postedFile.FileName);
                string fileName = "img-" + GetTimeStamp() + fileExtension;
                string fileFullPath = strPath + fileName;

                postedFile.SaveAs(fileFullPath);

                return fileName;
            }

            return string.Empty;
        }

        public static string GetTimeStamp()
        {
            StringBuilder sbTimeStamp = new StringBuilder(DateTime.Now.Year);
            sbTimeStamp.Append(DateTime.Now.Month);
            sbTimeStamp.Append(DateTime.Now.Day);
            sbTimeStamp.Append(DateTime.Now.Hour);
            sbTimeStamp.Append(DateTime.Now.Minute);
            sbTimeStamp.Append(DateTime.Now.Second);
            sbTimeStamp.Append(DateTime.Now.Millisecond);

            return sbTimeStamp.ToString();
        } 
    }
}