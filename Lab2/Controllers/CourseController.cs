using Humanizer;
using Lab2.Models.ViewModels;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Lab2.Repository;


namespace Lab2.Controllers
{
    public class CourseController : Controller
    {
        DataCon con;
        ICourse course;
        public CourseController(DataCon con, ICourse course)
        {
            this.con = con;
            this.course = course;
        }
        public IActionResult ShowAll()
        { 
            return View("ShowAll", course.GetAll());
        }

        public IActionResult Add_Course()
        {
            CourseVM coursevm = new();

            coursevm.departments = con.Departments.ToList();
            return View("Add_Course", coursevm);
        }

        [HttpPost]
        public IActionResult SaveAdded(Course newcourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    course.Add(newcourse);
                    return RedirectToAction("ShowAll", "Course");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.InnerException.Message);
                }
            }
            
            CourseVM coursevm = new();
            coursevm.departments = con.Departments.ToList();
            return View("Add_Course", coursevm);
        }

        public IActionResult Edit(int id)
        {
            Course course = con.Courses.FirstOrDefault(o => o.Course_ID == id);

            CourseVM coursevm = new();
            coursevm.Course_ID = course.Course_ID;
            coursevm.Course_Name = course.Course_Name;
            coursevm.hourse = course.hourse;
            coursevm.Degree = course.Degree;
            coursevm.Min_Degree = course.Min_Degree;
            coursevm.Dep_ID = course.Dep_ID;
            coursevm.departments = con.Departments.ToList();

            return View("Edit", coursevm);
        }

        public IActionResult SaveEdited(Course updatedcourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    course.Update(updatedcourse);
                    return RedirectToAction("ShowAll", "Course");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.InnerException.Message);
                }
            }

            CourseVM coursevm = new();
            coursevm.departments = con.Departments.ToList();
            return View("Edit", coursevm);
        }

        public IActionResult Delete(int id)
        {
         
           course.Delete(id);
           return RedirectToAction("ShowAll", "Course");
        }
    }
}
