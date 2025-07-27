namespace TestCoreApp.Areas.Employees.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public int? EmployeeAge { get; set; }
        public decimal? EmployeeSalary { get; set; }
    }
}
