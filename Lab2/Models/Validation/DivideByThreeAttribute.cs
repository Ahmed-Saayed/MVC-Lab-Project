using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.Validation
{
    public class DivideByThreeAttribute : ValidationAttribute
    {
        public DivideByThreeAttribute() { }
        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;
         
            if (!int.TryParse(value.ToString(), out int val))
                return false;
            
            if (val % 3 != 0)
            {
                ErrorMessage = "Value must be divided by three.";
                return false;
            }
            return true;
        }
    }
}
