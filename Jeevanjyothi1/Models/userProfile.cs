using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jeevanjyothi1.Models
{
    public class userProfile
    {
        public int userId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public bool enableSMS { get; set; }
    }
}