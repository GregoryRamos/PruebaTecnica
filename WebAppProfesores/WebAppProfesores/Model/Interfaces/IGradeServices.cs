using WebAppProfesores.Model.DTOs;

namespace WebAppProfesores.Model.Interfaces
{
    public interface IGradeServices : IBaseService<Grades>
    {
        List<GradesDTO> GetGradesBySubjectId(int subjectId);
        Task SaveGrades(List<GradesDTO> gradeslist);
    }
}
