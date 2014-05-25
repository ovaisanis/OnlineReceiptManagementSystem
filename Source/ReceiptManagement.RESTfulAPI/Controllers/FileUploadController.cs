using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ReceiptManagement.Bll.Managers;
using ReceiptManagement.RESTfulAPI.Common;
using ReceiptManagement.RESTfulAPI.Filters;
using ReceiptManagement.RESTfulAPI.Models;
using ReceiptManagement.RESTfulAPI.Utilities;

namespace ReceiptManagement.RESTfulAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        public const string DomainAddress = "http://localhost:22011";
        public const string FileLocationPath = "/UploadedFiles/Images/";
        public const string FileLocationRelativePath = "~" + FileLocationPath;
        public const string ServerImageDirectoryPath = DomainAddress + FileLocationPath;

        //public HttpResponseMessage Post(HttpPostedFileBase[] files)
        //public HttpResponseMessage Post(HttpPostedFileBase[] files)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { file_received="oh! Yesss" });
        //}

        //public async Task<IHttpActionResult> Upload()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //        throw new Exception(); // divided by zero

        //    var provider = new MultipartMemoryStreamProvider();
        //    await Request.Content.ReadAsMultipartAsync(provider);
        //    foreach (var file in provider.Contents)
        //    {
        //        var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //        var buffer = await file.ReadAsByteArrayAsync();
        //        //Do whatever you want with filename and its binaray data.
        //    }

        //    return Ok();
        //}

        //[ValidateRequestFilter]
        
        public HttpResponseMessage Post()
        {
            //var postedFile = httpRequest.Files[file];
            //var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
            //postedFile.SaveAs(filePath);

            HttpResponseMessage result = null;
            List<Image> uploadedImages = new List<Image>();
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    string nonImageFile;
                    if (CheckImageFileFormats(httpRequest.Files, out nonImageFile))
                    {
                        //foreach (string file in httpRequest.Files)
                        for(int i = 0; i < httpRequest.Files.Count; i++)
                        {
                            HttpPostedFile postedFile = httpRequest.Files[i];
                            var savedFileName = HelperMethods.SaveImage(postedFile, FileLocationRelativePath);

                            #region Insert Image Record in Database

                            ReceiptManagement.Common.Entities.Image image = new ReceiptManagement.Common.Entities.Image();

                            image.CreatedOn = DateTime.Now;
                            image.FileSize = 0;
                            image.Title = postedFile.FileName;
                            image.Path = savedFileName;
                            image.FileFormat = System.IO.Path.GetExtension(savedFileName);
                            image.IsDeleted = false;

                            long id;
                            new ImageManager().Insert(Context.GetContext(), image, out id);

                            #endregion

                            uploadedImages.Add(new Image
                            {
                                Id = id,
                                Title = postedFile.FileName,
                                Path = ServerImageDirectoryPath + savedFileName
                            });
                        }
                        result = Request.CreateResponse(HttpStatusCode.OK, new ResposeObject(uploadedImages));
                    }
                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.OK, new ResposeObject(nonImageFile + " is not an image file in your uploaded file(s)."));
                    }
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.OK, new ResposeObject("Please select any file to upload"));
                }
                
            }
            catch (Exception ex)
            {
                result = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Check Non image files
        /// </summary>
        /// <param name="files"></param>
        /// <param name="nonImageFileName"></param>
        /// <returns></returns>
        private bool CheckImageFileFormats(HttpFileCollection files, out string nonImageFileName)
        {
            nonImageFileName = string.Empty;
            bool status = true;

            foreach (string file in files)
            {
                var postedFile = files[file];
                string fileExtension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.') + 1).ToLower();
                if (fileExtension != "jpg" && fileExtension != "jpeg" && fileExtension != "gif" && fileExtension != "bmp" && fileExtension != "png")
                {
                    nonImageFileName = postedFile.FileName;
                    status = false;
                    break;
                }
            }


            return status;
        }
    }
}
