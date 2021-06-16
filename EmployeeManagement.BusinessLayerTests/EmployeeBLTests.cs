using EmployeeManagement.BusinessLayer;
using EmployeeManagement.DataAccessLayer;
using EmployeeManagement.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.BusinessLayerTests
{
    [TestClass]
    public class EmployeeBLTests
    {
        private IEmployeeBL employeeBl = null;

        [TestInitialize]
        public void TestSetup()
        {
            employeeBl = new EmployeeBL(new EmployeeDAL());

            SampleEmployeeData.Employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Clark", LastName = "Hills" },
                new Employee { Id = 3, FirstName = "Frank", LastName = "Evans" }
            };
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            var employees = employeeBl.GetAllEmployees();
            Assert.IsNotNull(employees);

            var count = employees.Count;
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void TestGetAllEmployees_ThrowsException()
        {
            employeeBl = new EmployeeBL(null);

            try
            {
                var employees = employeeBl.GetAllEmployees();
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex is EmployeeBLException);
            }
        }

        [TestMethod]
        public void TestGetEmployeeById()
        {
            int id = 3;
            var employee = employeeBl.GetEmployeeById(id);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.Id, id);
        }

        [TestMethod]
        public void TestGetEmployeeById_ThrowsException()
        {
            SampleEmployeeData.Employees = null;
            int id = 10;

            try
            {
                employeeBl.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex is EmployeeBLException);
            }
        }

        [TestMethod]
        public void TestAddEmployee()
        {
            var employees = employeeBl.GetAllEmployees();
            Assert.IsNotNull(employees);

            var count = employees.Count;
            Assert.IsTrue(count > 0);

            var newEmployee = new Employee
            {
                FirstName = "Sample first name",
                LastName = "Sample last name"
            };

            var addedEmployee = employeeBl.AddEmployee(newEmployee);

            employees = employeeBl.GetAllEmployees();
            Assert.IsNotNull(employees);

            var newCount = employees.Count;
            Assert.IsTrue(newCount == (count + 1));

            Assert.IsNotNull(addedEmployee);
            Assert.AreEqual(addedEmployee.FirstName, newEmployee.FirstName);
            Assert.AreEqual(addedEmployee.LastName, newEmployee.LastName);
        }

        [TestMethod]
        public void TestAddEmployee_ThrowsNullReferenceException()
        {
            try
            {
                employeeBl.AddEmployee(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [TestMethod]
        public void TestAddEmployee_ThrowsArgumentNullExceptionForFirstName()
        {
            try
            {
                employeeBl.AddEmployee(new Employee { FirstName = "", LastName = "Last name" });
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void TestAddEmployee_ThrowsArgumentNullExceptionForLastName()
        {
            try
            {
                employeeBl.AddEmployee(new Employee { LastName = "", FirstName = "First name" });
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
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
                employeeBl.AddEmployee(newEmployee);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex is EmployeeBLException);
            }
        }

        [TestMethod]
        public void TestDeleteEmployee()
        {
            var employees = employeeBl.GetAllEmployees();
            Assert.IsNotNull(employees);

            var count = employees.Count;
            Assert.IsTrue(count > 0);

            int id = employees.FirstOrDefault().Id;

            employeeBl.DeleteEmployeeById(id);

            employees = employeeBl.GetAllEmployees();
            Assert.IsNotNull(employees);

            var newCount = employees.Count;
            Assert.IsTrue(newCount == (count - 1));

            var employee = employeeBl.GetEmployeeById(id);

            Assert.IsNull(employee);
        }

        [TestMethod]
        public void TestDeleteEmployee_ThrowsException()
        {
            SampleEmployeeData.Employees = null;
            int id = 10;
            
            try
            {
                employeeBl.DeleteEmployeeById(id);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex is EmployeeBLException);
            }
        }
    }
}
