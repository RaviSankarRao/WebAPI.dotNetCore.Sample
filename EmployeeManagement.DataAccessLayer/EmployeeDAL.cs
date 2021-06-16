using EmployeeManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.DataAccessLayer
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> GetAllEmployees()
        {
            try
            {
                return SampleEmployeeData.Employees;
            }
            catch
            {
                throw new EmployeeDALExceptions("EmployeeDALException - While getting all employees");
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                var newEmployeeId = SampleEmployeeData.Employees.Count + 1;
                employee.Id = newEmployeeId;

                SampleEmployeeData.Employees.Add(employee);
                return employee;
            }
            catch
            {
                throw new EmployeeDALExceptions("EmployeeDALException - While adding employee");
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return SampleEmployeeData.Employees.FirstOrDefault(e => e.Id == id);
            }
            catch
            {

                throw new EmployeeDALExceptions("EmployeeDALException - While getting employee by id");
            }
        }

        public void DeleteEmployeeById(int id)
        {
            try
            {
                _ = SampleEmployeeData.Employees.RemoveAll(e => e.Id == id);
            }
            catch
            {
                throw new EmployeeDALExceptions("EmployeeDALException - While deleting employee by id");
            }
        }
    }
}
