using WebAppProfesores.Model.Enums;

namespace WebAppProfesores.Model
{
    public class Student : BaseEntity
    {

        public string Name { get; set; } 
        public GenderStudent Gender { get; set; }
        public DateTimeOffset Birthday { get; set; } 
        
    }
}
