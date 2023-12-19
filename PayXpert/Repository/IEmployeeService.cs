using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.entity;

namespace PayXpert.Repository
{
    public interface IEmployeeService
    {

        Employee GetEmployeeById(int employeeId);
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(int employeeId, string newFirstName);
        void RemoveEmployee(int employeeId);

        int CalculateEmployeeAge(int employeeId);

    }
}
