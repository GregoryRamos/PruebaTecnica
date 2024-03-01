using WebAppProfesores.Model.Interfaces;
using WebAppProfesores.Model;
using WebAppProfesores.Model.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebAppProfesores.Services
{
    public class AttendanceServices : BaseService<Attendance> , IAttendanceServices
    {

        public AttendanceServices(StudentContext context) : base(context)
        {

        }

        public List<AttendanceDTO>? GetAttendaceByDate(DateTimeOffset date, int subjectid)
        {
            List<AttendanceDTO> attendanceVM = new List<AttendanceDTO>();
            var attendancelist = this._context.Attendaces.Include(s=> s.Student).Where(a => a.Date == date && a.SubjectId== subjectid).ToList();
            if (attendancelist != null)
            {
                if (attendancelist.Count > 0)
                {
                    foreach (var attendance in attendancelist)
                    {
                        attendanceVM.Add(new AttendanceDTO()
                        {
                            Id= attendance.Id,
                            SubjectId = subjectid,
                            StudentId = attendance.StudentId,
                            Name = attendance.Student.Name,
                            Date = attendance.Date,
                            Status = attendance.Status,
                            Comment = attendance.comment
                        });
                    }
                    return attendanceVM;
                }
            }
            var students = this._context.Students.ToList();
            if (students != null) {
                foreach ( var student in students)
                {
                    attendanceVM.Add(new AttendanceDTO()
                    {
                        SubjectId = subjectid,
                        StudentId = student.Id,
                        Name = student.Name,
                        Date = date,
                        Status = Model.Enums.AttendaceStatus.Absent,
                        Comment = ""
                    });
                }
                return attendanceVM;
            }

            return null;

        }

        public async Task SaveAttendance(List<AttendanceDTO> attendancelist)
        {
            if (attendancelist.Any(x => x.Id == null))
            {
                foreach (var item in attendancelist)
                {
                    await this.CreateAsync(new Attendance
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
                    var itemtu = await this.GetByIdAsync((int)item.Id);
                    if (itemtu.Status != item.Status || itemtu.comment != item.Comment)
                    {
                        itemtu.Status = item.Status;
                        itemtu.comment = item.Comment;
                        await this.UpdateAsync(itemtu);
                    }

                }
            }

        }




    }
}
