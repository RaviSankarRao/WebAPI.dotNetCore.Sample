using EmployeeManagement.DataAccessLayer;
using EmployeeManagement.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccessLayerTests
{
    [TestClass]
    public class EmployeeDALTests
    {
        readonly IEmployeeDAL employeeDal = new EmployeeDAL();

        [TestInitialize]
        public void TestSetup()
        {
            SampleEmployeeData.Employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Clark", LastName = "Hills" },
                new Employee { Id = 3, FirstName = "Frank", LastName = "Evans" }
            };
        }

        [TestMethod]
        public void TestSampleData_Get()
        {
            Assert.IsNotNull(SampleEmployeeData.Employees);
            var count = SampleEmployeeData.Employees.Count;
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void TestSampleData_Set()
        {
            Assert.IsNotNull(SampleEmployeeData.Employees);
            var count = SampleEmployeeData.Employees.Count;
            Assert.IsTrue(count > 0);

            SampleEmployeeData.Employees = new List<Employee>();
            Assert.AreEqual(0, SampleEmployeeData.Employees.Count);
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            var employees = employeeDal.GetAllEmployees();
            Assert.IsNotNull(employees);

            var count = employees.Count;
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void TestGetAllEmployees_ThrowsException()
        {
            SampleEmployeeData.Employees = null;

            try
            {
                var employees = employeeDal.GetAllEmployees();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is EmployeeDALExceptions);
            }
        }

        [TestMethod]
        public void TestGetEmployeeById()
        {
            int id = 3;
            var employee = employeeDal.GetEmployeeById(id);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.Id, id);
        }

        [TestMethod]
        public void TestGetEmployeeById_ThrowsException()
        {
            int id = 3;
            SampleEmployeeData.Employees = null;

            try
            {
                var employee = employeeDal.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is EmployeeDALExceptions);
            }
        }

        [TestMethod]
        public void TestAddEmployee()
        {
            var employees = employeeDal.GetAllEmployees();
            Assert.IsNotNull(employees);

            var count = employees.Count;
            Assert.IsTrue(count > 0);

            var newEmployee = new Employee
            {
                FirstName = "Sample first name",
                LastName = "Sample last name"
            };

            var addedEmployee = employeeDal.AddEmployee(newEmployee);

            employees = employeeDal.GetAllEmployees();
            Assert.IsNotNull(employees);

            var newCount = employees.Count;
            Assert.IsTrue(newCount == (count + 1));

            Assert.IsNotNull(addedEmployee);
            Assert.AreEqual(addedEmployee.FirstName, newEmployee.FirstName);
            Assert.AreEqual(addedEmployee.LastName, newEmployee.LastName);
        }

        [TestMethod]
        public void TestAddEmployee_ThrowsException()
        {
            SampleEmployeeData.Employees = null;

            var newEmployee = new Employee
            {
                FirstName = "Sample first name",
                LastName = "Sample last name"
            };

            try
            {
                var addedEmployee = employeeDal.AddEmployee(newEmployee);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is EmployeeDALExceptions);
            }
        }

        [TestMethod]
        public void TestDeleteEmployee()
        {
            var employees = employeeDal.GetAllEmployees();
            Assert.IsNotNull(employees);

            var count = employees.Count;
            Assert.IsTrue(count > 0);

            int id = employees.FirstOrDefault().Id;

            employeeDal.DeleteEmployeeById(id);

            employees = employeeDal.GetAllEmployees();
            Assert.IsNotNull(employees);

            var newCount = employees.Count;
            Assert.IsTrue(newCount == (count - 1));

            var employee = employeeDal.GetEmployeeById(id);

            Assert.IsNull(employee);
        }

        [TestMethod]
        public void TestDeleteEmployee_ThrowsException()
        {
            int id = 3;
            SampleEmployeeData.Employees = null;

            try
            {
                employeeDal.DeleteEmployeeById(id);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is EmployeeDALExceptions);
            }

        }
    }
}
