using System.Reflection.Metadata.Ecma335;

namespace Lab2.Models
{
    public class Trainee
    {
        public int Trainee_Id { get; set; }
        public string Trainee_Name { get; set; }
        public string Image { get; set; }
        public double GradeYear { get; set; }
        public string Adress { get; set; }
        public int Dep_ID { get; set; }
        public Department Department { get; set; }
        public List<crsResult> crsResults { get; set; }
    }
}
