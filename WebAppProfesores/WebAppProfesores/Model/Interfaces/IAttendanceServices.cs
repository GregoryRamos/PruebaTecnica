using WebAppProfesores.Model.ViewModels;

namespace WebAppProfesores.Model.Interfaces
{
    public interface IAttendanceServices : IBaseService<Attendance>
    {
        List<AttendanceDTO>? GetAttendaceByDate(DateTimeOffset date, int subjectid);
        Task SaveAttendance(List<AttendanceDTO> attendancelist);
    }
}
