using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Slate.Models;

namespace Slate.Controllers
{
    public class ShiftsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Shifts
        public IQueryable<Shift> Getshift()
        {
            return db.shift;
        }

        // GET: api/Shifts/5
        [ResponseType(typeof(Shift))]
        public async Task<IHttpActionResult> GetShift(int id)
        {
            Shift shift = await db.shift.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }

            return Ok(shift);
        }

        // PUT: api/Shifts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShift(int id, Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shift.ShiftId)
            {
                return BadRequest();
            }

            db.Entry(shift).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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

        // POST: api/Shifts
        [ResponseType(typeof(Shift))]
        public async Task<IHttpActionResult> PostShift(Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.shift.Add(shift);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shift.ShiftId }, shift);
        }

        // DELETE: api/Shifts/5
        [ResponseType(typeof(Shift))]
        public async Task<IHttpActionResult> DeleteShift(int id)
        {
            Shift shift = await db.shift.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }

            db.shift.Remove(shift);
            await db.SaveChangesAsync();

            return Ok(shift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShiftExists(int id)
        {
            return db.shift.Count(e => e.ShiftId == id) > 0;
        }
    }
}