namespace WebAppProfesores.Model
{
    public class Grades : BaseEntity
    {
        public int StudentId { get; set; } 
        public int SubjectId { get; set; }  
        public int Score { get; set; }  

    }
}
