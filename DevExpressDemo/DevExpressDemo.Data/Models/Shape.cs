using System.ComponentModel.DataAnnotations;

namespace DevExpressDemo.Data.Models
{
    public class Shape
    {
        [Key]
        public int ShapeId { get; set; }

        public string ShapeInfo { get; set; }
    }
}
