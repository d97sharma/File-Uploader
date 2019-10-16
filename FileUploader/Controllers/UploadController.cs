//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web.Hosting;
//using System.Web.Mvc;
////using Microsoft.AspNetCore.Hosting;
////using Microsoft.AspNetCore.Mvc;

//namespace FileUploader.Controllers
//{
//    public class UploadController : Controller
//    {
//        // GET: Upload
//        private HostingEnvironment _hostingEnvironment;

//        public UploadController(HostingEnvironment hostingEnvironment)
//        {
//            _hostingEnvironment = hostingEnvironment;
//        }

//        [HttpPost]//, DisableRequestSizeLimit]
//        public ActionResult UploadFile()
//        {
//            try
//            {
//                foreach (var file in Request.Form.Files)
//                {
//                    string folderName = "Upload";
//                    string webRootPath = _hostingEnvironment.WebRootPath;
//                    string newPath = Path.Combine(webRootPath, folderName);
//                    if (!Directory.Exists(newPath))
//                    {
//                        Directory.CreateDirectory(newPath);
//                    }
//                    if (file.Length > 0)
//                    {
//                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//                        string fullPath = Path.Combine(newPath, fileName);
//                        using (var stream = new FileStream(fullPath, FileMode.Create))
//                        {
//                            file.CopyTo(stream);
//                        }
//                    }
//                }

//                return Json("Upload Successful.");
//            }
//            catch (System.Exception ex)
//            {
//                return Json("Upload Failed: " + ex.Message);
//            }
//        }

//    }
//}