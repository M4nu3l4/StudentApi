
// Controllers/StudentsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.DTOs;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.Profile) 
                .ToListAsync();

            return students.Select(s => new StudentReadDto
            {
                Id = s.Id,
                Nome = s.Nome,
                Cognome = s.Cognome,
                Email = s.Email,
                Profile = s.Profile == null ? null : new StudentProfileReadDto
                {
                    Id = s.Profile.Id,
                    FirstName = s.Profile.FirstName,
                    LastName = s.Profile.LastName,
                    FiscalCode = s.Profile.FiscalCode,
                    BirthDate = s.Profile.BirthDate
                }
            }).ToList();
        }


        // POST
        [HttpPost]
        public async Task<ActionResult<StudentReadDto>> PostStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                Nome = dto.Nome,
                Cognome = dto.Cognome,
                Email = dto.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, new StudentReadDto
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                Email = student.Email
            });
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDto dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.Nome = dto.Nome;
            student.Cognome = dto.Cognome;
            student.Email = dto.Email;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.Profile)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            var studentDto = new StudentReadDto
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                Email = student.Email,
                Profile = student.Profile == null ? null : new StudentProfileReadDto
                {
                    Id = student.Profile.Id,
                    FirstName = student.Profile.FirstName,
                    LastName = student.Profile.LastName,
                    FiscalCode = student.Profile.FiscalCode,
                    BirthDate = student.Profile.BirthDate
                }
            };

            return Ok(studentDto);
        }

    }
}
