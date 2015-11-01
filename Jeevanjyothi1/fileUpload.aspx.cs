using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jeevanjyothi1
{
    public partial class fileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                FileUpload1.Visible = false;
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string finalFileName = userid.Value + Path.GetExtension(FileUpload1.PostedFile.FileName);

                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/images/users/") + finalFileName);
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}