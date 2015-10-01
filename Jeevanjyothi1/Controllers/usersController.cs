using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Jeevanjyothi1.Models;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web.Configuration;

namespace Jeevanjyothi1.Controllers
{
    public class usersController : ApiController
    {
        private jeevanjyothi_dbEntities db = new jeevanjyothi_dbEntities();

        // GET: api/users
        public IQueryable<user> Getusers()
        {
            return db.users;
        }

        // GET: api/users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Getuser(int id)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser(int id, user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("validate/{userid}/{password}")]
        [HttpGet]
        public dynamic checkLogin(long userid, string password)
        {

            db.Configuration.ProxyCreationEnabled = false;

            password = Encrypt(password);



            var abc = (from recordset in db.users
                       where recordset.mobile == userid && recordset.password.Equals(password)
                       select recordset);

            return abc;


//            return db.users.Count(recordset => recordset.mobile == userid && recordset.password.Equals(password));
        
        }

        // POST: api/users
        [ResponseType(typeof(user))]
        public IHttpActionResult Postuser(user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string defaultPassword = WebConfigurationManager.AppSettings["defaultPassword"];

            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            user.createdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            user.password = Encrypt(defaultPassword);

            db.users.Add(user);
            db.SaveChanges();

            if (user.id > 0) {

                string sendSingleSmsUrl = WebConfigurationManager.AppSettings["sendSingleSmsUrl"];
                string smsUserId = WebConfigurationManager.AppSettings["smsUserId"];
                string smsPassword = WebConfigurationManager.AppSettings["smsPassword"];
                string smsFrom = WebConfigurationManager.AppSettings["smsFrom"];
                string smsRegisterMsgTemplate = WebConfigurationManager.AppSettings["smsRegisterMsgTemplate"];

                smsRegisterMsgTemplate = String.Format(smsRegisterMsgTemplate, user.fullname.Replace(" ", "+"), user.mobile, defaultPassword);
                sendSingleSmsUrl = String.Format(sendSingleSmsUrl, smsUserId, smsPassword, smsFrom, user.mobile, smsRegisterMsgTemplate, "&");

                string output;

                using (WebClient client = new WebClient())
                {
                    output = client.DownloadString(sendSingleSmsUrl);
                }

                smsoutput smsoutput = new smsoutput();

                smsoutput.sentAction = "r";
                smsoutput.output = output;
                smsoutput.createDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                smsoutput.actionid = user.id;

                db.smsoutputs.Add(smsoutput);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = user.id }, user);
        }

        // DELETE: api/users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Deleteuser(int id)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(int id)
        {
            return db.users.Count(e => e.id == id) > 0;
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}