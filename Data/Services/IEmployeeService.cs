using System.Collections.Generic;
using System.Threading.Tasks;
using DataAcess.Models;

namespace DataAccess.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}