using Lab2.Models;

namespace Lab2.Repository.Services
{
    public class CourseServices : ICourse
    {
        DataCon context;
        public CourseServices()
        {
            context = new DataCon();
        }
        public void Add(Course obj)
        {
            context.Courses.Add(obj);

            Save();
        }

        public void Delete(int id)
        {
            context.Courses.Remove(GetByID(id));
            Save();
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetByID(int id)
        {
            return context.Courses.FirstOrDefault(e => e.Course_ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Course obj)
        {
            Course course = GetByID(obj.Course_ID);

           // context.Courses.Update(obj);/*
            course.Course_Name = obj.Course_Name;
            course.hourse = obj.hourse;
            course.Degree = obj.Degree;
            course.Min_Degree = obj.Min_Degree;
            course.Dep_ID = obj.Dep_ID;
            Save();

        }
    }
}
