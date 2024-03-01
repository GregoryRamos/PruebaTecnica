using Microsoft.AspNetCore.Mvc;
using WebAppProfesores.Model.Interfaces;
using WebAppProfesores.Model;

namespace WebAppProfesores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;

        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            
            await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            try
            {
                if (string.IsNullOrEmpty(student.Name))
                {
                    throw new Exception("No puede existir un estudiante sin nombre");
                }
                await _studentService.UpdateAsync(student);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
                
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            await _studentService.DeleteAsync(id);
            return NoContent();

        }
    }

}
