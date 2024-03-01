using WebAppProfesores.Model;
using WebAppProfesores.Model.Interfaces;

namespace WebAppProfesores.Services
{
    public class StudentServices : BaseService<Student>, IStudentServices
    {
        public StudentServices(StudentContext context) : base(context)
        { 

        }    

        
    }
}
