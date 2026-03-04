using System.ComponentModel.DataAnnotations;
using Lab2.Models.ViewModels;

namespace Lab2.Models.Validation
{
    public class UniqueAttribute : ValidationAttribute
    {
        DataCon context = new();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string? name = value.ToString();
            Course? courseFromReq = validationContext.ObjectInstance as Course;

            if (courseFromReq == null)
                return ValidationResult.Success;

            Course? courseFromdb = context.Courses
                .FirstOrDefault(e => e.Course_Name == name && e.Dep_ID == courseFromReq.Dep_ID);

            if (courseFromdb == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Course name already exists in this department");
        }
    }
}
