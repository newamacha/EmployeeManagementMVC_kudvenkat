using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMVC.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required] 
        public string RoleName { get; set; }
    }
}
