using System;
using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public int DepId { get; set; }
        public int EmployeeSex { get; set; }
        public string EmployeeNo { get; set; }
        public int? EmployeeAge { get; set; }
        public DateTime? BirthDate { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEducation { get; set; }
        public string EmployeeOpus { get; set; }
    }
}