using BusinessLogic.Implementation;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Factory
{
    public class SalaryFactory : ISalaryFactory
    {
        public ISalary SelectEmployeeType(string Type)
        {
            ISalary salary;
            if (Type.Equals("HourlySalaryEmployee"))
            {
                salary = new HourlySalary();
            }else
            {
                salary = new MonthlySalary();
            }

            return salary;
        }

    }
}
