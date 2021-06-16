using AutoMapper;
using EmployeeManagement.BusinessLayer;
using EmployeeManagement.DataAccessLayer;
using EmployeeManagementService.Controllers;
using EmployeeManagementService.Mappers;
using EmployeeManagementService.Models;
using EmployeeManagementService.Repository;
using EmployeeManagementService.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;

namespace EmployeeManagementServiceTests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        IEmployeeRepository _employeeRepository;
        IEmployeeBL _employeeBl;
        IEmployeeDAL _employeeDal;
        IMapper mapper;
        EmployeeController employeeController;

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
            employeeController = new EmployeeController(_employeeRepository);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnEmployeeList()
        {
            var response = employeeController.GetAllEmployees();
            var result = response as EmployeeServiceResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result.ResponseData);

            var employees = DeserializeEmployees(result.ResponseData);
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnErrorResponse()
        {
            employeeController = new EmployeeController(null);
            var response = employeeController.GetAllEmployees();
            var result = response as ErrorResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.InternalServerError);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnEmployeeById()
        {
            int employeeId = 1;
            var response = employeeController.GetEmployeeById(employeeId);
            var result = response as EmployeeServiceResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            EmployeeModel employee = DeserializeEmployee(result.ResponseData);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.Id, employeeId);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnNotFound()
        {
            int employeeId = 7;
            var response = employeeController.GetEmployeeById(employeeId);
            var result = response as EmployeeServiceResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnErrorResponse()
        {
            int employeeId = 7;
            employeeController = new EmployeeController(null);
            var response = employeeController.GetEmployeeById(employeeId);
            var result = response as ErrorResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.InternalServerError);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void AddEmployee_ShouldAddEmployee()
        {
            var newEmployee = new EmployeeModel
            {
                FirstName = "Ravi Sankar Rao",
                LastName = "Dasari"
            };

            var response = employeeController.AddEmployee(newEmployee);
            var result = response as EmployeeServiceResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.Created);

            EmployeeModel employee = DeserializeEmployee(result.ResponseData);
            Assert.IsTrue(employee.Id > 0);
            Assert.AreEqual(employee.FirstName, newEmployee.FirstName);
        }

        [TestMethod]
        public void AddEmployee_ShouldReturnErrorResponse()
        {
            var response = employeeController.AddEmployee(null);
            var result = response as ErrorResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.InternalServerError);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void DeleteEmployeeById_ShouldDeleteEmployeeById()
        {
            int employeeId = 2;
            var response = employeeController.GetEmployeeById(employeeId);
            var result = response as EmployeeServiceResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            EmployeeModel employee = DeserializeEmployee(result.ResponseData);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.Id, employeeId);

            response = employeeController.DeleteEmployee(employeeId);
            result = response as EmployeeServiceResponse;
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NoContent);

            response = employeeController.GetEmployeeById(employeeId);
            result = response as EmployeeServiceResponse;
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void DeleteEmployeeById_ShouldReturnNotFound()
        {
            int employeeId = 5;
            var response = employeeController.DeleteEmployee(employeeId);
            var result = response as EmployeeServiceResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void DeleteEmployeeById_ShouldReturnErrorResponse()
        {
            int employeeId = 5;
            employeeController = new EmployeeController(null);
            var response = employeeController.DeleteEmployee(employeeId);
            var result = response as ErrorResponse;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.InternalServerError);
            Assert.IsNotNull(result.Message);
        }

        private static List<EmployeeModel> DeserializeEmployees(object respone)
        {
            var employees = (List<EmployeeModel>)respone;
            return employees;
        }

        private static EmployeeModel DeserializeEmployee(object respone)
        {
            var employee = (EmployeeModel) respone;
            return employee;
        }
    }
}
