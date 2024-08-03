using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
