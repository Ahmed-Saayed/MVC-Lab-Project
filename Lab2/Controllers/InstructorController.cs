using Lab2.Models;
using Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class InstructorController : Controller
    {
        DataCon con = new DataCon();
        public IActionResult ShowAll()
        {
            List<Instructor> allins = con.Instructors.ToList();

            return View("Show_All_Instructors", allins);
        }
        public IActionResult Index(int ins_Id)
        {
            Instructor ins = con.Instructors.FirstOrDefault(o => o.Inst_Id == ins_Id);
          
            return View("Instructor_View", ins);
        }

        public IActionResult AddInstructor() 
        {
            InstructorVM instructorVM = new InstructorVM();
            instructorVM.departments = con.Departments.ToList();
            instructorVM.courses = con.Courses.ToList();

            return View("Add_Instructor", instructorVM);
        }

        public IActionResult SaveAdded(InstructorVM instructorvm)
        {
            if (instructorvm.Inst_Name != null)
            {

                Instructor instructor = new();

                instructor.Inst_Name = instructorvm.Inst_Name;
                instructor.Adress = instructorvm.Adress;
                instructor.Image = instructorvm.Image;
                instructor.salary = instructorvm.salary;
                instructor.Dep_ID = instructorvm.Dep_ID;
                instructor.Course_id = instructorvm.Course_id;

                con.Instructors.Add(instructor);
                con.SaveChanges();

                return RedirectToAction("ShowAll");

            }
            instructorvm.departments = con.Departments.ToList();
            instructorvm.courses = con.Courses.ToList();

            return View("Add_Instructor", instructorvm);
        }

        public IActionResult Edit(int id)
        {
            Instructor instructor = con.Instructors.FirstOrDefault(o => o.Inst_Id == id);

            InstructorVM instructorVm = new InstructorVM();
            instructorVm.Inst_Id = instructor.Inst_Id;
            instructorVm.Inst_Name = instructor.Inst_Name;
            instructorVm.Adress = instructor.Adress;
            instructorVm.Image = instructor.Image;
            instructorVm.Course_id = instructor.Course_id;
            instructorVm.Dep_ID = instructor.Dep_ID;
            instructorVm.salary = instructor.salary;
            instructorVm.departments = con.Departments.ToList();
            instructorVm.courses = con.Courses.ToList();

            return View("Edit", instructorVm);
        }

        [HttpPost]
        public IActionResult SaveEdit(InstructorVM instructorvm)
        {
            if (instructorvm.Inst_Name != null)
            {
             
                Instructor instructor = con.Instructors.FirstOrDefault(e => e.Inst_Id == instructorvm.Inst_Id);

                instructor.Inst_Name = instructorvm.Inst_Name;
                instructor.Image = instructorvm.Image;
                instructor.salary = instructorvm.salary;
                instructor.Dep_ID = instructorvm.Dep_ID;
                instructor.Course_id = instructor.Course_id;

                con.SaveChanges();
                return RedirectToAction("ShowAll");

            }
            instructorvm.departments = con.Departments.ToList();
            instructorvm.courses = con.Courses.ToList();

            return View("Edit", instructorvm);
        }
    }
}
