using System;

namespace Indra.Infrastructure.Data.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

    }
}
