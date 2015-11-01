using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Jeevanjyothi1
{
    /// <summary>
    /// Summary description for imageUpload
    /// </summary>
    public class imageUpload : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                string dirFullPath = HttpContext.Current.Server.MapPath("~/images/users/");
                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;

                string str_image = "";

                foreach (string s in context.Request.Files)
                {

                    HttpPostedFile file = context.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = Path.GetExtension(fileName);
                        str_image = "user" + context.Request["id"] + fileExtension;
                        string pathToSave = HttpContext.Current.Server.MapPath("~/images/users/") + str_image;

                        file.SaveAs(pathToSave);

                    }
                }
                context.Response.Write(str_image);
            }
            catch (Exception ex)
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}