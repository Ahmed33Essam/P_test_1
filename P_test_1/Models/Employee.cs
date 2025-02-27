using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace P_test_1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Full Name")]
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        [Unique]
        [Remote(action:"CheckName",controller:"Employee",AdditionalFields = "Address", ErrorMessage ="Rewrite the Name.......")]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Display(Name="Job Title")] 
        public string JobTitle { get; set; }

        //[Required]
        [RegularExpression(@"\w+\.(png|jpg)", ErrorMessage = "the Img must be png or jpg")]
        public string? ImageURL { get; set; }

        [Display(Name = "Upload File")]
        [NotMapped]
        public IFormFile? Image { get; set; }

        [RegularExpression(@"(Minya|Assuit|Alex)", ErrorMessage = "choose one Minya|Assuit|Alex")]
        public string? Address { get; set; }

        [Display(Name="Department")]
        [ForeignKey("Department")]
        [Range(1,int.MaxValue, ErrorMessage = "Plz make choose")]
        public int DptID { get; set; }
        public Department? Department { get; set; }
    }
}
