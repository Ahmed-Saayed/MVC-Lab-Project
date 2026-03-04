using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.Validation
{
    public class MoreThanAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (Course)validationContext.ObjectInstance;

            if (value == null)
                return ValidationResult.Success;

            int degree = (int)value;

            if (degree >= course.Min_Degree)
                return ValidationResult.Success;

            return new ValidationResult("Degree must be greater than or equal to Min Degree");
        }
    }
}