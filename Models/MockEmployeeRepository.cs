using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee() { ID = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
                new Employee() { ID = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
                new Employee() { ID = 3, Name = "Sam", Department = Dept.IT, Email = "sam@pragimtech.com" },
            };
        }

        public Employee Add(Employee employee)
        {
            employee.ID = _employees.Max(e => e.ID) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Delete(int ID)
        {
            Employee employee = _employees.FirstOrDefault(e => e.ID == ID);
            if(employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployee(int ID)
        {
            return _employees.FirstOrDefault(e => e.ID == ID);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employees.FirstOrDefault(e => e.ID == employeeChanges.ID);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
