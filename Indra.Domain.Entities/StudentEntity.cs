using Indra.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;

namespace Indra.Domain.Entities
{
    public class StudentEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public static StudentEntity MapFromStudentModel(Student student)
        {
            return new StudentEntity
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday,
                Age = student.Age
            };
        }

        public static Student MapToStudentModel(StudentEntity student)
        {
            return new Student
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday,
                Age = student.Age
            };
        }

        public static IEnumerable<StudentEntity> MapFromStudentModelList(IEnumerable<Student> students)
        {
            List<StudentEntity> studentEntities = new List<StudentEntity>();
            foreach (var student in students)
            {
                studentEntities.Add(MapFromStudentModel(student));
            }
            return studentEntities;
        }

        public static IEnumerable<Student> MapToStudentModelList(IEnumerable<StudentEntity> studentEntities)
        {
            List<Student> students = new List<Student>();
            foreach (var studentEntity in studentEntities)
            {
                students.Add(MapToStudentModel(studentEntity));
            }
            return students;
        }
    }
}
