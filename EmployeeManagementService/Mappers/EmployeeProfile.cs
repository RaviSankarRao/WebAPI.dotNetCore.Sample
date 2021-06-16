using AutoMapper;
using EmployeeManagement.DataContracts;
using EmployeeManagementService.Models;

namespace EmployeeManagementService.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeModel>();
        }
    }
}
