using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Data.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }

        public string DepNo { get; set; }
        public string DepName { get; set; }
        public string OfficeLocation { get; set; }
    }
}
