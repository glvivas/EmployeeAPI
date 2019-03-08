using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Models;

namespace BusinessLogic.Logic
{
    public interface IEmployeeLogic
    {
        Task<EmployeeResponseModel> GetEmployeeAsync(int id);
        Task<IEnumerable<EmployeeResponseModel>> GetEmployeesAsync();
    }
}