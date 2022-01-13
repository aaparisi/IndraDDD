using Indra.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Indra.Web.Dto
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public static StudentEntity MapToStudentEntity(StudentDTO student)
        {
            return new StudentEntity
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday
            };
        }

        public static StudentDTO MapFromStudentEntity(StudentEntity student)
        {
            return new StudentDTO
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday
            };
        }

        public static IEnumerable<StudentDTO> MapFromStudentEntityList(IEnumerable<StudentEntity> studentEntities)
        {
            List<StudentDTO> studentDTOs = new List<StudentDTO>();
            foreach (var student in studentEntities)
            {
                studentDTOs.Add(MapFromStudentEntity(student));
            }
            return studentDTOs;
        }
    }
}
