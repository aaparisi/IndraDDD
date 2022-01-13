
using Indra.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indra.Application.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentEntity>> GetAll();
        public Task<StudentEntity> Get(int id);
        public Task<StudentEntity> Insert(StudentEntity studentEntity);
        public Task<bool> Remove(int id);
        public Task<StudentEntity> Update(StudentEntity student);
    }
}
