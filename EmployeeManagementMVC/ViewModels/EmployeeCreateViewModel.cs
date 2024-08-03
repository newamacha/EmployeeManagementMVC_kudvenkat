using EmployeeManagementMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMVC.ViewModels
{
    public class EmployeeCreateViewModel
    {
        
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public IFormFile Photo { get; set; }
    }
}
