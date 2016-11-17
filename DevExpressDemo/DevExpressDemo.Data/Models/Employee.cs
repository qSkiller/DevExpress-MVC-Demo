using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { set; get; }

        public string EmployeeName { set; get; }
        public string EmployeePhone { set; get; }
        public string EmployeeAddress { set; get; }
        public string EmployeeEducation { set; get; }
        public string EmployeeOpus { set; get; }
    }
}