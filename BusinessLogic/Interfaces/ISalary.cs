using DataAcess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ISalary
    {
        double GetAnualSalary(Employee employee);
        double GetSalary(Employee employee);
    }
}
