using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeManagementMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        [AllowNull]
        public string ReturnUrl { get; set; }
    }
}
