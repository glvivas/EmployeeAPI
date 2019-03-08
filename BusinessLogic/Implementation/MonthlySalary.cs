using BusinessLogic.Interfaces;
using DataAcess.Models;

namespace BusinessLogic.Implementation
{
    public class MonthlySalary : ISalary
    {
        public double GetAnualSalary(Employee employee)
        {
            return employee.MonthlySalary * 12;
        }

        public double GetSalary(Employee employee)
        {
            return employee.MonthlySalary;
        }
    }
}
