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
using MediaWebApi.Models;

namespace MediaWebApi.Controllers
{
    public class MediaController : ApiController
    {
        private MediaWebApiContext db = new MediaWebApiContext();

        // GET: api/Media
        public IQueryable<Media> GetMedia()
        {
            return db.Media;
        }

        // GET: api/Media/5
        [ResponseType(typeof(Media))]
        public IHttpActionResult GetMedia(long id)
        {
            Media media = db.Media.Find(id);
            if (media == null)
            {
                return NotFound();
            }

            return Ok(media);
        }

        // PUT: api/Media/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedia(long id, Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != media.Id)
            {
                return BadRequest();
            }

            db.Entry(media).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // POST: api/Media
        [ResponseType(typeof(Media))]
        public IHttpActionResult PostMedia(Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Media.Add(media);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = media.Id }, media);
        }

        // DELETE: api/Media/5
        [ResponseType(typeof(Media))]
        public IHttpActionResult DeleteMedia(long id)
        {
            Media media = db.Media.Find(id);
            if (media == null)
            {
                return NotFound();
            }

            db.Media.Remove(media);
            db.SaveChanges();

            return Ok(media);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediaExists(long id)
        {
            return db.Media.Count(e => e.Id == id) > 0;
        }
    }
}