using Microsoft.AspNetCore.Mvc;
using WebAppProfesores.Model.DTOs;
using WebAppProfesores.Model.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppProfesores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeServices _gradeServices;

        public GradesController(IGradeServices gradeServices)
        {
            _gradeServices = gradeServices;
        }



        // GET api/<GradesController>/5
        [HttpGet("{Subjectid}")]
        public IActionResult Get(int Subjectid)
        {
           return  Ok(_gradeServices.GetGradesBySubjectId(Subjectid));
        }

        // POST api/<GradesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<GradesDTO> gradeslist)
        {
            try
            {
                await _gradeServices.SaveGrades(gradeslist);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
