using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Logic;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeLogic employeeLogic;

        public EmployeesController(IEmployeeLogic employeeLogic)
        {
            this.employeeLogic = employeeLogic;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponseModel>>> GetAsync()
        {
            IEnumerable<EmployeeResponseModel> employeeResponses = await employeeLogic.GetEmployeesAsync();

            return Ok(employeeResponses);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            EmployeeResponseModel employeeResponse = await employeeLogic.GetEmployeeAsync(id);
            return Ok(employeeResponse);
        }        
    }
}
