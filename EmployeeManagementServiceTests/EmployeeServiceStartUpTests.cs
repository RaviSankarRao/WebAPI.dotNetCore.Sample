using EmployeeManagement.BusinessLayer;
using EmployeeManagement.DataAccessLayer;
using EmployeeManagementService;
using EmployeeManagementService.Mappers;
using EmployeeManagementService.Repository;
using EmployeeManagementService.Setup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementServiceTests
{
    [TestClass]
    public class EmployeeServiceStartUpTests
    {
        [TestMethod]
        public void StartupTest_VerifyDependecnyInjection()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
            Assert.IsNotNull(webHost.Services.GetRequiredService<IEmployeeDAL>());
            Assert.IsNotNull(webHost.Services.GetRequiredService<IEmployeeBL>());
            Assert.IsNotNull(webHost.Services.GetRequiredService<IEmployeeRepository>());
        }
    }
}
