using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DevExpressDemo.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Must be under 50 characters")]
        public string EmployeeName { get; set; }

        public int DepId { get; set; }

        [Display(Name = "Sex")]
        [Required(ErrorMessage = "Sex is required")]
        public string EmployeeSex { get; set; }

        [Display(Name = "EmployeeNo")]
        [Required(ErrorMessage = "EmployeeNo is required")]
        public string EmployeeNo { get; set; }

        [Display(Name = "Age")]
        [Range(18,100,ErrorMessage = "Must be between 18 and 100")]
        public int? EmployeeAge { get; set; }

        [Display(Name="Birth Date")]
        [Required(ErrorMessage = "Birth date is required")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone date is required")]
        public string EmployeePhone { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email is invalid")]
        public string EmployeeEmail { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEducation { get; set; }
        public string EmployeeOpus { get; set; }
    }
}