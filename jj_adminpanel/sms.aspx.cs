using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jj_adminpanel
{
    public partial class sms : System.Web.UI.Page
    {
        public string retString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://www.metamorphsystems.com/index.php/api/get-balance?username=sujanmanikanta&password=123456";

            using (WebClient client = new WebClient())
            {
                retString = client.DownloadString(url);
                retString = retString.Split(',')[1].Split(':')[1];
                retString = retString.Remove(retString.Length - 1).Trim();
            }




        }
    }
}