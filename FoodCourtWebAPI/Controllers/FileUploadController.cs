using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodCourtWebAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        public string UploadFiles()
        {
            string strFilefullPath = string.Empty;
            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            string storeRelativePath = System.Configuration.ConfigurationManager.AppSettings["UploadStoreFolder"];
            sPath = System.Web.Hosting.HostingEnvironment.MapPath(storeRelativePath);

            System.Web.HttpPostedFile hpf = System.Web.HttpContext.Current.Request.Files[0];
            if (hpf.ContentLength > 0)
            {
                // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                {
                    // SAVE THE FILES IN THE FOLDER.
                    hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                }
            }
            strFilefullPath = storeRelativePath + hpf.FileName;
            // RETURN files name to be save in db
            return strFilefullPath;
        }
    }
}