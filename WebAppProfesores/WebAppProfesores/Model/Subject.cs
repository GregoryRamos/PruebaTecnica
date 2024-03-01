namespace WebAppProfesores.Model
{
    public class Subject: BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public virtual ICollection<Attendance>? Attendances { get; set; }
        public virtual ICollection<Grades>? Grades { get; set; }
    }
}
