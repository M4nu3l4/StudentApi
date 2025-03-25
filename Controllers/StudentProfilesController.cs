using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Data;
using StudentApi.DTOs;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfilesController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentProfilesController(StudentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(StudentProfileCreateDto dto)
        {
            var student = await _context.Students.FindAsync(dto.StudentId);
            if (student == null) return NotFound("Studente non trovato.");

            var profile = new StudentProfile
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FiscalCode = dto.FiscalCode,
                BirthDate = dto.BirthDate,
                StudentId = dto.StudentId
            };

            _context.StudentProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return Ok(profile);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, StudentProfileUpdateDto dto)
        {
            var profile = await _context.StudentProfiles.FindAsync(id);
            if (profile == null)
                return NotFound();

            profile.FirstName = dto.FirstName;
            profile.LastName = dto.LastName;
            profile.FiscalCode = dto.FiscalCode;
            profile.BirthDate = dto.BirthDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.StudentProfiles.FindAsync(id);
            if (profile == null)
                return NotFound();

            _context.StudentProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
