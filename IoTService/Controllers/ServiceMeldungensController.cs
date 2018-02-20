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
using IoTService;

namespace IoTService.Controllers
{
    public class ServiceMeldungensController : ApiController
    {
        private MeldungsModel db = new MeldungsModel();

        // GET: api/ServiceMeldungens
        public IQueryable<ServiceMeldungen> GetServiceMeldungen()
        {
            return db.ServiceMeldungen;
        }

        // GET: api/ServiceMeldungens/5
        [ResponseType(typeof(ServiceMeldungen))]
        public IHttpActionResult GetServiceMeldungen(int id)
        {
            ServiceMeldungen serviceMeldungen = db.ServiceMeldungen.Find(id);
            if (serviceMeldungen == null)
            {
                return NotFound();
            }

            return Ok(serviceMeldungen);
        }

        // PUT: api/ServiceMeldungens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceMeldungen(int id, ServiceMeldungen serviceMeldungen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceMeldungen.Id)
            {
                return BadRequest();
            }

            db.Entry(serviceMeldungen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceMeldungenExists(id))
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

        // POST: api/ServiceMeldungens
        [ResponseType(typeof(ServiceMeldungen))]
        public IHttpActionResult PostServiceMeldungen(ServiceMeldungen serviceMeldungen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceMeldungen.Add(serviceMeldungen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceMeldungen.Id }, serviceMeldungen);
        }

        // DELETE: api/ServiceMeldungens/5
        [ResponseType(typeof(ServiceMeldungen))]
        public IHttpActionResult DeleteServiceMeldungen(int id)
        {
            ServiceMeldungen serviceMeldungen = db.ServiceMeldungen.Find(id);
            if (serviceMeldungen == null)
            {
                return NotFound();
            }

            db.ServiceMeldungen.Remove(serviceMeldungen);
            db.SaveChanges();

            return Ok(serviceMeldungen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceMeldungenExists(int id)
        {
            return db.ServiceMeldungen.Count(e => e.Id == id) > 0;
        }
    }
}