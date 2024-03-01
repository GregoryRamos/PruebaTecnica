namespace WebAppProfesores.Model
{
    public class Grades : BaseEntity
    {
        public int StudentId { get; set; } 
        public Student? Student { get; set; }
        public int SubjectId { get; set; } 
        public Subject? Subject { get; set; }
        public int Score { get; set; }  

    }
}
