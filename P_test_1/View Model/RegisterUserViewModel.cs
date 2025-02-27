using System.ComponentModel.DataAnnotations;

namespace P_test_1.View_Model
{
    public class RegisterUserViewModel
    {
        public string Name { set; get; }

        [DataType(DataType.Password)]
        public string Password { set; get; }


        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { set; get; }

        public string Address { set; get; }
    }
}
