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

namespace Jeevanjyothi1.Controllers
{
    public class requirementsController : ApiController
    {
        private jeevanjyothi_dbEntities db = new jeevanjyothi_dbEntities();

        // GET: api/requirements
        public IQueryable<requirement> Getrequirements()
        {
            return db.requirements;
        }

        // GET: api/requirements/5
        [ResponseType(typeof(requirement))]
        public IHttpActionResult Getrequirement(int id)
        {
            requirement requirement = db.requirements.Find(id);
            if (requirement == null)
            {
                return NotFound();
            }

            return Ok(requirement);
        }

        // PUT: api/requirements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrequirement(int id, requirement requirement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requirement.id)
            {
                return BadRequest();
            }

            db.Entry(requirement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!requirementExists(id))
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

        // POST: api/requirements
        [ResponseType(typeof(requirement))]
        public IHttpActionResult Postrequirement(requirement requirement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.requirements.Add(requirement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requirement.id }, requirement);
        }

        // DELETE: api/requirements/5
        [ResponseType(typeof(requirement))]
        public IHttpActionResult Deleterequirement(int id)
        {
            requirement requirement = db.requirements.Find(id);
            if (requirement == null)
            {
                return NotFound();
            }

            db.requirements.Remove(requirement);
            db.SaveChanges();

            return Ok(requirement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool requirementExists(int id)
        {
            return db.requirements.Count(e => e.id == id) > 0;
        }
    }
}