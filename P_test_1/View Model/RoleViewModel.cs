using System.ComponentModel.DataAnnotations;

namespace P_test_1.View_Model
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { set; get; }
    }
}
