using EmployeeManagementService.Models;
using EmployeeManagementService.Repository;
using EmployeeManagementService.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementService.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Returns list of all employees
        /// Http: GET
        /// Route: api/Employee
        /// </summary>
        /// <returns>Http action result</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAllEmployees();
                var response = new EmployeeServiceResponse(employees);
                return response;
            }
            catch
            {
                return new ErrorResponse("Error while getting all employee", HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Returns an employee for the given employee id
        /// Http: GET
        /// Route: api/Employee/1
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>Http action result</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                    return new EmployeeServiceResponse(null, HttpStatusCode.NotFound);

                var response = new EmployeeServiceResponse(employee);
                return response;
            }
            catch
            {
                return new ErrorResponse("Error while getting employee by id", HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Adds an employee
        /// Http: POST
        /// Route: api/Employee
        /// </summary>
        /// <param name="employeeModel">employee object as post body</param>
        /// <returns>Http action result</returns>
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeModel model)
        {
            try
            {
                var employee = _employeeRepository.AddEmployee(model);
                var response = new EmployeeServiceResponse(employee, HttpStatusCode.Created);
                return response;
            }
            catch
            {
                return new ErrorResponse("Error while adding employee", HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes an employee from the system
        /// Http: DELETE
        /// Route: api/Employee/1
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>Http action result</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                    return new EmployeeServiceResponse(null, HttpStatusCode.NotFound);

                _employeeRepository.DeleteEmployeeById(id);
                var response = new EmployeeServiceResponse(null, HttpStatusCode.NoContent);

                return response;
            }
            catch
            {
                return new ErrorResponse("Error while deleting employee", HttpStatusCode.InternalServerError);
            }
        }
    }
}
