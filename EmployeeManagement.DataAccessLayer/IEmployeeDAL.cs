using EmployeeManagement.DataContracts;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccessLayer
{
    public interface IEmployeeDAL
    {
        List<Employee> GetAllEmployees();

        Employee AddEmployee(Employee employee);

        Employee GetEmployeeById(int id);

        void DeleteEmployeeById(int id);
    }
}
