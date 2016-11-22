
using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        //[DisplayFormat(NullDisplayText = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 5)]
        public string Password { get; set; }
        
        [Display(Name = "ConfirmPassword")]
        [Compare("ConfirmPassword", ErrorMessage = "The passowrd you entered do not match. ")]
        public string ConfirmPassword { get; set; }
    }
}