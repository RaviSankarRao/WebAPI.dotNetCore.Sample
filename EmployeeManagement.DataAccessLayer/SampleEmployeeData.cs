using EmployeeManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccessLayer
{
    public static class SampleEmployeeData
    {
        private static readonly List<Employee> employeeList = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
            new Employee { Id = 2, FirstName = "Clark", LastName = "Hills" },
            new Employee { Id = 3, FirstName = "Frank", LastName = "Evans" }
        };

        private static List<Employee> employees = employeeList;

        public static List<Employee> Employees 
        { 
            get => employees; 
            set => employees = value; 
        }
    }
}
