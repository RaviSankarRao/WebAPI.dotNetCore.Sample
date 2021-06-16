using AutoMapper;
using EmployeeManagement.BusinessLayer;
using EmployeeManagement.DataContracts;
using EmployeeManagementService.Models;
using System.Collections.Generic;

namespace EmployeeManagementService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly IEmployeeBL _employeeBl;
        private readonly IMapper _mapper;

        public EmployeeRepository(IEmployeeBL employeeBl, IMapper mapper)
        {
            _employeeBl = employeeBl;
            _mapper = mapper;  
        }

        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);
            var addedEmployee = _employeeBl.AddEmployee(employee);
            return _mapper.Map<EmployeeModel>(addedEmployee);
        }

        public void DeleteEmployeeById(int id)
        {
            _employeeBl.DeleteEmployeeById(id);
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            var employees = _employeeBl.GetAllEmployees();
            return _mapper.Map<List<EmployeeModel>>(employees); ;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var employee = _employeeBl.GetEmployeeById(id);
            return _mapper.Map<EmployeeModel>(employee);
        }
    }
}
