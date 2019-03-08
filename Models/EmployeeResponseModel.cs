namespace DTO.Models
{
    public class EmployeeResponseModel
    {
        public int  Id {get; set;}
        public string Name {get; set;}
        public string ContractTypeName {get; set;}
        public int RoleId {get; set;}
        public string RoleName {get; set;}
        public string RoleDescription {get; set;}
        public double Salary { get; set; }
        public double AnualSalary { get; set; }
    }
}
