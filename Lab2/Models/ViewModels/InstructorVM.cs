namespace Lab2.Models.ViewModels
{
    public class InstructorVM
    {
        public int Inst_Id { get; set; }
        public string Inst_Name { get; set; }
        public string Image { get; set; }
        public double salary { get; set; }
        public string Adress { get; set; }
        public int Course_id { get; set; }
        public int Dep_ID { get; set; }
        public List<Department> departments { get; set; }
        public List<Course> courses { get; set; }
    }
}
