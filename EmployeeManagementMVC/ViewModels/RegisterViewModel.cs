﻿using EmployeeManagementMVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        [ValidEmailDomain(allowedDomain: "gmail.com", ErrorMessage ="Email domain must be gmail.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
                ErrorMessage ="Password doesnot match.")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
