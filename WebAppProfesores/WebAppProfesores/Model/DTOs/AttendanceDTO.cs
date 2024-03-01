using WebAppProfesores.Model.Enums;

namespace WebAppProfesores.Model.ViewModels
{
    public class AttendanceDTO
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public AttendaceStatus Status { get; set; }
        public string? Comment { get; set; }
    }
}
