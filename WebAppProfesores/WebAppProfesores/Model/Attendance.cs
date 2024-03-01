using WebAppProfesores.Model.Enums;

namespace WebAppProfesores.Model
{
    public class Attendance : BaseEntity
    {
        public int StudentId { get; set; } 
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTimeOffset Date { get; set; }    
        public AttendaceStatus Status { get; set; } 
        public string? comment { get; set; }

    }
}
