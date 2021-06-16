using AutoMapper;
using EmployeeManagement.BusinessLayer;
using EmployeeManagement.DataAccessLayer;
using EmployeeManagementService.Mappers;
using EmployeeManagementService.Models;
using EmployeeManagementService.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementServiceTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        IEmployeeBL _employeeBl;
        IEmployeeDAL _employeeDal;
        IMapper mapper;
        IEmployeeRepository _employeeRepository;

        [TestInitialize]
        public void Setup()
        {
            _employeeDal = new EmployeeDAL();
            _employeeBl = new EmployeeBL(_employeeDal);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmployeeProfile());
            });

            mapper = mockMapper.CreateMapper();

            _employeeRepository = new EmployeeRepository(_employeeBl, mapper);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnEmployeeList()
        {
            var employees = _employeeRepository.GetAllEmployees();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnEmployeeById()
        {
            int employeeId = 1;
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.Id, employeeId);
        }

        [TestMethod]
        public void AddEmployee_ShouldAddEmployee()
        {
            var newEmployee = new EmployeeModel
            {
                FirstName = "Ravi Sankar Rao",
                LastName = "Dasari"
            };

            var employee = _employeeRepository.AddEmployee(newEmployee);

            Assert.IsTrue(employee.Id > 0);
            Assert.AreEqual(employee.FirstName, newEmployee.FirstName);
        }

        [TestMethod]
        public void DeleteEmployeeById_ShouldDeleteEmployeeById()
        {
            int employeeId = 3;
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            Assert.IsNotNull(employee);

            _employeeRepository.DeleteEmployeeById(employeeId);

            employee = _employeeRepository.GetEmployeeById(employeeId);
            Assert.IsNull(employee);
        }
    }
}
