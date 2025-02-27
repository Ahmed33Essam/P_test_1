using System.ComponentModel.DataAnnotations;

namespace P_test_1.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            string newName = value.ToString();
            ITIContext contex = new ITIContext();
            Employee employee = contex.Employees.FirstOrDefault(x => x.Name == newName);
            //Employee demp = (Employee)validationContext.ObjectInstance;
            if (employee != null)
                return new ValidationResult("the name is used");

            return ValidationResult.Success;
        }
    }
}
