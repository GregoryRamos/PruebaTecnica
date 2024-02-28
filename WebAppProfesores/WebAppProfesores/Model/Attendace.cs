using WebAppProfesores.Model.Enums;

namespace WebAppProfesores.Model
{
    public class Attendace : BaseEntity
    {
        public int StudentId { get; set; } 
        public int SubjectId { get; set; } 
        public DateTimeOffset Date { get; set; }    
        public AttendaceStatus Status { get; set; } 

    }
}
