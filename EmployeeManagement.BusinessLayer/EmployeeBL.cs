using EmployeeManagement.DataAccessLayer;
using EmployeeManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.BusinessLayer
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeDAL _employeeDal;

        public EmployeeBL(IEmployeeDAL employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public Employee AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new NullReferenceException("Parameter cannot be null");

            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
                throw new ArgumentNullException("First name or last name cannot be null");

            try
            {
                return _employeeDal.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new EmployeeBLException("EmployeeBLException - While adding new employee", ex);
            }
        }

        public void DeleteEmployeeById(int id)
        {
            try
            {
                _employeeDal.DeleteEmployeeById(id);
            }
            catch (Exception ex)
            {
                throw new EmployeeBLException("EmployeeBLException - While deleting employee by id", ex);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _employeeDal.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw new EmployeeBLException("EmployeeBLException - While getting all employees", ex);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return _employeeDal.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                throw new EmployeeBLException("EmployeeBLException - While getting employee by id", ex);
            }
        }
    }
}
