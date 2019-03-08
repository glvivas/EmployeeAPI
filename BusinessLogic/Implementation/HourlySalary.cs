using BusinessLogic.Interfaces;
using DataAcess.Models;

namespace BusinessLogic.Implementation
{
    public class HourlySalary : ISalary
    {
        public double GetAnualSalary(Employee employee)
        {
            return 120 * employee.HourlySalary * 12;
        }

        public double GetSalary(Employee employee)
        {
            return employee.HourlySalary;
        }
    }
}
