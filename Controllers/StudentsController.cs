using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound(new { message = "Student not found" });
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent([FromBody] Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                return BadRequest(new { message = "Name is required" });

            if (string.IsNullOrWhiteSpace(student.Course))
                return BadRequest(new { message = "Course is required" });

            if (string.IsNullOrWhiteSpace(student.Level))
                return BadRequest(new { message = "Level is required" });

            if (student.Age < 15 || student.Age > 100)
                return BadRequest(new { message = "Age must be between 15 and 100" });

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> PutStudent(int id, [FromBody] Student updated)
        {
            if (updated is null) return BadRequest(new { message = "Request body is empty" });

            if (string.IsNullOrWhiteSpace(updated.Name))
                return BadRequest(new { message = "Name is required" });

            if (string.IsNullOrWhiteSpace(updated.Course))
                return BadRequest(new { message = "Course is required" });

            if (string.IsNullOrWhiteSpace(updated.Level))
                return BadRequest(new { message = "Level is required" });

            if (updated.Age < 15 || updated.Age > 100)
                return BadRequest(new { message = "Age must be between 15 and 100" });

            var existing = await _context.Students.FindAsync(id);
            if (existing == null) return NotFound(new { message = "Student not found" });

            existing.Name = updated.Name;
            existing.Age = updated.Age;
            existing.Course = updated.Course;
            existing.Level = updated.Level;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existing = await _context.Students.FindAsync(id);
            if (existing == null) return NotFound(new { message = "Student not found" });

            _context.Students.Remove(existing);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Student with id {id} deleted" });
        }
    }
}
