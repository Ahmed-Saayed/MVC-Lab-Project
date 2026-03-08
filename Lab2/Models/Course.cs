using Lab2.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Course
    {
        public int Course_ID { get; set; }

        [MaxLength(25, ErrorMessage = "Name Must be less than 25")]
        [MinLength(3)]
        [Unique]
        public string Course_Name { get; set; }
        [MoreThan]
        public int Degree { get; set; }
        public int Min_Degree { get; set; }
        [DivideByThree]
        public string hourse { get; set; }
        public int Dep_ID { get; set; }
        public Department? Department { get; set; }
        public List<Instructor>? instructors { get; set; }
        public List<crsResult>? crsResults { get; set; }

    }
}
