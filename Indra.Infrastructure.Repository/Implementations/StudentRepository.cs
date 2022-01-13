
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {

        public StudentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Student> UpdateAsync(Student student)
        {
            var dbStudent = await _unitOfWork.Context.Students
                .FirstOrDefaultAsync(d => d.StudentId == student.StudentId);

            if (student.Name != null)
                dbStudent.Name = student.Name;
            if (student.Surname != null)
                dbStudent.Surname = student.Surname;
            if (student.Age != null)
                dbStudent.Age = student.Age;
            if (student.Birthday != null)
                dbStudent.StudentId = student.StudentId;

            return dbStudent;
        }
    }
}
