using BusinessLogic.Factory;
using BusinessLogic.Interfaces;
using DataAccess.Services;
using DataAcess.Models;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeService employeeService;
        private readonly ISalaryFactory salaryFactory;
        private ISalary EmployeeSalary;

        public EmployeeLogic(IEmployeeService employeeService, ISalaryFactory salaryFactory)
        {
            this.employeeService = employeeService;
            this.salaryFactory = salaryFactory;
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await employeeService.GetEmployees();

            IEnumerable<EmployeeResponseModel> employeeModel = employees.Select(s => new EmployeeResponseModel {
                Id = s.Id,
                RoleId = s.RoleId,
                RoleName = s.RoleName,
                Name = s.Name,
                RoleDescription = s.RoleDescription,
                ContractTypeName = s.ContractTypeName,
                Salary = salaryFactory.SelectEmployeeType(s.ContractTypeName).GetSalary(s),
                AnualSalary = salaryFactory.SelectEmployeeType(s.ContractTypeName).GetAnualSalary(s)                
            });

            return employeeModel;
        }

        public async Task<EmployeeResponseModel> GetEmployeeAsync(int id)
        {
            EmployeeResponseModel employeeModel = new EmployeeResponseModel();
            IEnumerable<Employee> employees = await employeeService.GetEmployees();
            Employee employee = employees.SingleOrDefault(s => s.Id == id);
            if(employee != null)
            {
                ISalary salary = salaryFactory.SelectEmployeeType(employee.ContractTypeName);
                employeeModel = new EmployeeResponseModel
                {
                    Id = employee.Id,
                    RoleId = employee.RoleId,
                    RoleName = employee.RoleName,
                    Name = employee.Name,
                    RoleDescription = employee.RoleDescription,
                    ContractTypeName = employee.ContractTypeName,
                    Salary = salary.GetSalary(employee),
                    AnualSalary = salary.GetAnualSalary(employee)
                };
            }
            

            return employeeModel;
        }
    }
}
