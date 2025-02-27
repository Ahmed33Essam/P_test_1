using System.ComponentModel.DataAnnotations;

namespace P_test_1.View_Model
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { set; get; }

        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { set; get; }
    }
}
