using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementMVC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Sanam",
                    Department = Dept.IT,
                    Email = "hello123@gmail.com",
                    PhotoPath = ""
                }
                //new Employee
                //{
                //    Id = 2,
                //    Name = "Sweety",
                //    Department = Dept.HR,
                //    Email = "hi@gmail.com"
                //}
            );
        }
    }
}
