using Lab2.Models;
using Lab2.Models.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.ViewModels
{
    public class CourseVM
    {
        public int Course_ID { get; set; }
        public string Course_Name { get; set; }
        public int Degree { get; set; }
        public int Min_Degree { get; set; }
        public string hourse { get; set; }
        public int Dep_ID { get; set; }
        public List<Department>? departments { get; set; }
    }
}
