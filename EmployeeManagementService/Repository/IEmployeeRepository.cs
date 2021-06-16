using EmployeeManagementService.Models;
using System.Collections.Generic;

namespace EmployeeManagementService.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetAllEmployees();
        EmployeeModel AddEmployee(EmployeeModel employeeModel);
        EmployeeModel GetEmployeeById(int id);
        void DeleteEmployeeById(int id);
    }
}
