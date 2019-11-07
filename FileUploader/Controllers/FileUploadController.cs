using FileUploader.Models;
using System;
using System.Collections.Generic;
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
    public class FileUploadController : ApiController
    {

        [System.Runtime.InteropServices.ComVisible(true)]
        
        [Route("files")]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                  
                    var filePath = "C:\\UploadedPDFs\\" + postedFile.FileName;
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




        //// GET: FileUpload
        //private static readonly string ServerUploadFolder = "C:\\Temp"; //Path.GetTempPath();

        //[Route("files")]
        //[HttpPost]
        //[ValidateMimeMultipartContentFilter]

        //public async Task<FileResult> UploadSingleFile()
        //{
        //    var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
        //    await Request.Content.ReadAsMultipartAsync(streamProvider);

        //    return new FileResult
        //    {
        //        FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
        //        Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
        //        ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
        //        Description = streamProvider.FormData["description"],
        //        CreatedTimestamp = DateTime.UtcNow,
        //        UpdatedTimestamp = DateTime.UtcNow,
        //        DownloadLink = "TODO, will implement when file is persisited"
        //    };
        //}
    }
}