using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { set; get; }

        public string UserName { set; get; }
        public string Password { set; get; }

    }
}