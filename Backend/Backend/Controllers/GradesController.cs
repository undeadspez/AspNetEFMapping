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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GradesController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Grades
        public async Task<IEnumerable<GradeDTO>> GetGrades()
        {
            var dtos = await db.Grades
                .OrderBy(g => g.GradeId)
                .ProjectTo<GradeDTO>()
                .ToListAsync();

            return dtos;
        }

        // GET: api/Grades/5
        [ResponseType(typeof(GradeDTO))]
        public async Task<IHttpActionResult> GetGrade(int id)
        {
            Grade grade = await db.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<GradeDTO>(grade);
            return Ok(dto);
        }

        // PUT: api/Grades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrade(int id, Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grade.GradeId)
            {
                return BadRequest();
            }

            db.Entry(grade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        [ResponseType(typeof(GradeDTO))]
        public async Task<IHttpActionResult> PostGrade(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grades.Add(grade);
            await db.SaveChangesAsync();

            var dto = Mapper.Map<GradeDTO>(grade);
            return CreatedAtRoute("DefaultApi", new { id = grade.GradeId }, dto);
        }

        // DELETE: api/Grades/5
        [ResponseType(typeof(GradeDTO))]
        public async Task<IHttpActionResult> DeleteGrade(int id)
        {
            Grade grade = await db.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            db.Grades.Remove(grade);
            await db.SaveChangesAsync();

            var dto = Mapper.Map<GradeDTO>(grade);
            return Ok(dto);
        }

        [ResponseType(typeof(StudentDTO))]
        [Route("api/Grades/{id}/Student")]
        public async Task<IHttpActionResult> GetGradeStudent(int id)
        {
            var grade = await db.Grades
                .Include(g => g.Student)
                .FirstOrDefaultAsync(g => g.GradeId == id);

            if (grade != null)
            {
                var dto = Mapper.Map<StudentDTO>(grade.Student);
                return Ok(dto);
            }
            else
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradeExists(int id)
        {
            return db.Grades.Count(e => e.GradeId == id) > 0;
        }
    }
}