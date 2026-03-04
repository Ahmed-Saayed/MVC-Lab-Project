namespace Lab2.Models
{
    public class crsResult
    {
        public int ID { get; set; }
        public int Degree { get; set; }
        public int Course_ID { get; set; }
        public Course course { get; set; }
        public int Trainee_ID { get; set; }
        public Trainee trainee { get; set; }
    }
}
