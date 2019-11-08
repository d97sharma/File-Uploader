using FileUploader.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace FileUploader.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/upload")]
    public class ImageUploadController : ApiController
    {
        // GET: ImageUpload
        [System.Runtime.InteropServices.ComVisible(true)]

        [Route("images")]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            
            if (httpRequest.Files.Count > 0)
            {
                //to make a new folder if it does not exist
                string Parentdirectory = "C:\\Uploaded Files\\" + httpRequest.Form["FileType"];
                if (!Directory.Exists(Parentdirectory))
                    Directory.CreateDirectory(Parentdirectory);

                //deletes all files in the directory
                System.IO.DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Uploaded Files\\" + httpRequest.Form["FileType"] + "\\");

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                {
                    directory.Delete(true);
                }

                // Forming the path to save templates based on user
                string fileType = httpRequest.Form["FileType"] + "\\"; 

                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = "C:\\Uploaded Files\\" + fileType + postedFile.FileName;
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}