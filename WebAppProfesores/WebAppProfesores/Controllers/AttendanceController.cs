using Microsoft.AspNetCore.Mvc;
using WebAppProfesores.Model;
using WebAppProfesores.Model.Interfaces;
using WebAppProfesores.Model.ViewModels;
using WebAppProfesores.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppProfesores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceServices _attendanceService;

        public AttendanceController(IAttendanceServices attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public IActionResult GetAllBydate(int subjectid, string date)
        {            
            return Ok(_attendanceService.GetAttendaceByDate(DateTimeOffset.Parse(date),subjectid));
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<AttendanceDTO> attendancelist)
        {
            try
            {
                await _attendanceService.SaveAttendance(attendancelist);  
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

       
    }
}
