using Indra.Application.Services.Interfaces;
using Indra.Domain.Entities;
using Indra.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indra.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentEntity> Get(int id)
        {
            var repositoryResult = await _studentRepository.GetByIdAsync(id);
            return StudentEntity.MapFromStudentModel(repositoryResult);
        }

        public async Task<IEnumerable<StudentEntity>> GetAll()
        {
            var repositoryResult = await _studentRepository.GetAllAsync();
            return StudentEntity.MapFromStudentModelList(repositoryResult);
        }

        public async Task<StudentEntity> Insert(StudentEntity studentEntity)
        {
            studentEntity.Age = CalculateAge(studentEntity.Birthday);
            var insertedStudent = await _studentRepository.InsertAsync(StudentEntity.MapToStudentModel(studentEntity));
            _unitOfWork.Commit();
            return StudentEntity.MapFromStudentModel(insertedStudent);
        }

        public Task<bool> Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentEntity> Update(StudentEntity student)
        {
            throw new System.NotImplementedException();
        }

        public static int CalculateAge(DateTime birthday)
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear)
                age--;
            return age;
        }
    }
}
