using Lab2.Models;
using Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class TraineeController : Controller
    {
        DataCon con;
        public TraineeController(DataCon con)
        {
            this.con = con;
        }
        [HttpGet("GO/{traineeId}/{crsID}")]
        public IActionResult Index(int traineeId, int crsID)
        {
             crsResult crs = con.crsResults.Where(c => c.Trainee_ID == traineeId && c.Course_ID == crsID).First();
             Course course = con.Courses.Where(c => c.Course_ID == crsID).First();

            ShowResult result = new()
            {
                CourseName = course.Course_Name,
                TraineeName = con.Trainees.Where(t => t.Trainee_Id == traineeId).First().Trainee_Name,
                ok = course.Min_Degree <= crs.Degree,
                Degree = crs.Degree
            };

            return View(result);
        }
    }
}
