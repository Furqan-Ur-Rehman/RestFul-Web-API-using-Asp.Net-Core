using Creating_AspCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Creating_AspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        //Create DbContext Class Object below
        private readonly AspCoreWebApidbContext _context;

        //Create Parameterized Constructor
        public StudentAPIController(AspCoreWebApidbContext context) 
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents() 
        {
            var data = await _context.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var data_by_id = await _context.Students.FindAsync(id);
            if (data_by_id == null)
            { 
                return NotFound();
            }
            return Ok(data_by_id);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
           if(id != student.Id)
            {
                return BadRequest();
            }
           _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var data = await _context.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.Students.Remove(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
