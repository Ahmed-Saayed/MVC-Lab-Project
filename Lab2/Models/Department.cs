namespace Lab2.Models
{
    public class Department
    {
        public int Department_ID { get; set; }
        public string Dep_Name { get; set; }
        public string Manager_Name { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Trainee>?Trainees { get; set; }
        public List<Instructor>? Instructors { get; set; }

    }
}
