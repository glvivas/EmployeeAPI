using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataAccess.Services;
using DataAcess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Logic;
using BusinessLogic.Factory;
using BusinessLogic.Implementation;
using DTO.Models;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class EmployeeLogicTests
    {
        private Mock<IEmployeeService> employeeServiceMock;
        private Mock<ISalaryFactory> salaryFactoryMock;
        private EmployeeLogic employeeLogic;
        IEnumerable<Employee> employees;

        [TestInitialize]
        public void SetUp()
        {
            employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Juan" ,
                    ContractTypeName = "HourlySalaryEmployee",
                    RoleId= 1,
                    RoleName= "Administrator",
                    RoleDescription= null,
                    HourlySalary= 60000,
                    MonthlySalary= 80000
                },
                new Employee
                {
                    Id = 1,
                    Name = "Pedro" ,
                    ContractTypeName = "MonthlySalaryEmployee",
                    RoleId= 1,
                    RoleName= "Administrator",
                    RoleDescription= null,
                    HourlySalary= 60000,
                    MonthlySalary= 80000
                }
            };
            employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(s => s.GetEmployees()).Returns(Task.FromResult(employees));

            salaryFactoryMock = new Mock<ISalaryFactory>();
            salaryFactoryMock.Setup(s => s.SelectEmployeeType("MonthlySalaryEmployee")).Returns(new MonthlySalary());
            salaryFactoryMock.Setup(s => s.SelectEmployeeType("HourlySalaryEmployee")).Returns(new HourlySalary());
            employeeLogic = new EmployeeLogic(employeeServiceMock.Object, salaryFactoryMock.Object);
        }

        [TestMethod]
        public async Task GetEmployeesAsync_WhenList_ReturnsListAsync()
        {
            IEnumerable<EmployeeResponseModel> result = await employeeLogic.GetEmployeesAsync();

            Assert.AreEqual(2, result.Count());
        }
    }
}
