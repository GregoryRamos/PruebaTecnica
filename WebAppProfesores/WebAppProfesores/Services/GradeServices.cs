using Microsoft.EntityFrameworkCore;
using WebAppProfesores.Model;
using WebAppProfesores.Model.DTOs;
using WebAppProfesores.Model.Interfaces;

namespace WebAppProfesores.Services
{
    public class GradeServices : BaseService<Grades>, IGradeServices
    {
        public GradeServices(StudentContext context) : base(context)
        {

        }

        public List<GradesDTO> GetGradesBySubjectId(int subjectId)
        {
            List<GradesDTO> Gradeslist = new List<GradesDTO>();
            var students = this._context.Students.Include(x=> x.Grades).ToList();


            foreach (var student in students)
            {
                if (student.Grades!=null)
                {
                    if (student.Grades.Any(x => x.SubjectId == subjectId))
                    {
                        var currentGrade = student.Grades.FirstOrDefault(x => x.SubjectId == subjectId);
                        Gradeslist.Add(new GradesDTO()
                        {
                            Id = currentGrade.Id,
                            SubjectId = subjectId,
                            StudentId = student.Id,
                            Name= student.Name,
                            Grades = currentGrade == null ? 0 :  currentGrade.Score
                        });
                        continue;
                    }
                }
                Gradeslist.Add(new GradesDTO()
                {
                    SubjectId = subjectId,
                    StudentId = student.Id,
                    Name = student.Name,
                    Grades = 0
                });
            }
            return Gradeslist;
        }

        public async Task   SaveGrades(List<GradesDTO> gradeslist)
        {
            foreach (var grade in gradeslist)
            {
                if (grade.Id == null)
                {
                    await this.CreateAsync(new Grades()
                    {
                        StudentId = grade.StudentId,
                        SubjectId = grade.SubjectId,
                        Score = grade.Grades
                    });
                }
                else
                {
                    var itemtu = await this.GetByIdAsync((int)grade.Id);
                    if (itemtu.Score != grade.Grades)
                    {
                        itemtu.Score = grade.Grades;
                        await this.UpdateAsync(itemtu);
                    }
                }
            }

        }




    }
}
