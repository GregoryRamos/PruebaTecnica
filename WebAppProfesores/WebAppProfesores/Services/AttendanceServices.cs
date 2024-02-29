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

        public List<AttendanceViewModel>? GetAttendaceByDate(DateTimeOffset date, int subjectid)
        {
            List<AttendanceViewModel> attendanceVM = new List<AttendanceViewModel>();
            var attendancelist = this._context.Attendaces.Include(s=> s.Student).Where(a => a.Date == date && a.SubjectId== subjectid).ToList();
            if (attendancelist != null)
            {
                if (attendancelist.Count > 0)
                {
                    foreach (var attendance in attendancelist)
                    {
                        attendanceVM.Add(new AttendanceViewModel()
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
                    attendanceVM.Add(new AttendanceViewModel()
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






    }
}
