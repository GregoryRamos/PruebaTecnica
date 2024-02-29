using WebAppProfesores.Model.ViewModels;

namespace WebAppProfesores.Model.Interfaces
{
    public interface IAttendanceServices : IBaseService<Attendance>
    {
        List<AttendanceViewModel>? GetAttendaceByDate(DateTimeOffset date, int subjectid);
    }
}
