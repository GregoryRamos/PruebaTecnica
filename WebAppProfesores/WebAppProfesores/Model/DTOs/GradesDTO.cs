namespace WebAppProfesores.Model.DTOs
{
    public class GradesDTO
    {
        public int? Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }        
        public string? Name { get; set; }
        public int Grades { get; set; }
    }
}
