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
using Backend.DTOs;
using Backend.Models;

namespace Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Students
        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var dtos = await db.Students
                .OrderBy(s => s.StudentId)
                .ProjectTo<StudentDTO>()
                .ToListAsync();

            return dtos;
        }

        // GET: api/Students/5
        [ResponseType(typeof(StudentDTO))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<StudentDTO>(student);
            return Ok(dto);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        [ResponseType(typeof(StudentDTO))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var dto = Mapper.Map<StudentDTO>(student);
            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, dto);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(StudentDTO))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            await db.SaveChangesAsync();

            var dto = Mapper.Map<StudentDTO>(student);
            return Ok(dto);
        }

        [ResponseType(typeof(IEnumerable<GradeDTO>))]
        [Route("api/Students/{id}/Grades")]
        public async Task<IHttpActionResult> GetStudentGrades(int id)
        {
            var student = await db.Students
                .Include(s => s.Grades)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student != null)
            {
                var dtos = Mapper.Map<GradeDTO[]>(student.Grades);
                return Ok(dtos);
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

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}