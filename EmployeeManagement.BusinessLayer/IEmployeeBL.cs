using EmployeeManagement.DataContracts;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessLayer
{
    public interface IEmployeeBL
    {
        List<Employee> GetAllEmployees();

        Employee AddEmployee(Employee employee);

        Employee GetEmployeeById(int id);

        void DeleteEmployeeById(int id);
    }
}
