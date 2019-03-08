using BusinessLogic.Interfaces;

namespace BusinessLogic.Factory
{
    public interface ISalaryFactory
    {
        ISalary SelectEmployeeType(string Type);
    }
}