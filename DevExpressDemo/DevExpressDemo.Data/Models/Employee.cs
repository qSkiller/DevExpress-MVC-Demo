using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEducation { get; set; }
        public string EmployeeOpus { get; set; }
    }
}