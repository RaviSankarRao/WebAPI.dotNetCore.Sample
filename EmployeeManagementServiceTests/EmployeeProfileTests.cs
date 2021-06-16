using AutoMapper;
using EmployeeManagementService.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementServiceTests
{
    [TestClass]
    public class EmployeeProfileTests
    {
        [TestMethod]
        public void TestIfMapperConfigurationIsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
