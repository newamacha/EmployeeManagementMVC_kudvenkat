namespace EmployeeManagementMVC.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository() 
        {
            //_employeeList = new List<Employee>()
            //{
            //    new Employee() {Id = 1, Name = "Sanam", Department = Dept.IT, Email = "hello@gmail.com"},
            //    new Employee() {Id = 2, Name = "Sweety", Department = Dept.HR, Email = "bonjour@gmail.com"},
            //    new Employee() {Id = 3, Name = "Mukesh", Department = Dept.IT, Email = "hi@gmail.com"},
            //};
        }

        public Employee Add(Employee employee)
        {
            employee.Id=_employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee= _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id==id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }
            return employee;
        }
    }
}
