using P_test_1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_test_1.View_Model
{
    public class EmpwithDeptListVM
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [DataType(DataType.Password)]
        public string Name { get; set; }
        public int Salary { get; set; }
        public string JobTitle { get; set; }
        public string ImageURL { get; set; }
        public string? Address { get; set; }
        public int DptID { get; set; }

        public List<Department> Departments { get; set; }
    }
}
