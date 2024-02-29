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
        public async Task<IActionResult> Post([FromBody] List<AttendanceViewModel> attendancelist)
        {
            try
            {
                if (attendancelist.Any(x => x.Id == null))
                {
                    foreach (var item in attendancelist)
                    {
                        await _attendanceService.CreateAsync(new Attendance
                        {
                            StudentId = item.StudentId,
                            SubjectId = item.SubjectId,
                            Date = item.Date,
                            comment = item.Comment,
                            Status = item.Status,
                        });
                    }
                }
                else
                {

                    foreach (var item in attendancelist)
                    {
                        var itemtu = await _attendanceService.GetByIdAsync((int)item.Id);
                        if (itemtu.Status != item.Status || itemtu.comment != item.Comment )
                        {
                            itemtu.Status = item.Status;
                            itemtu.comment = item.Comment;
                            await _attendanceService.UpdateAsync(itemtu);
                        }
                       
                    }
                }

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
            


        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
