using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Orderid { get; set; }
        [ForeignKey("Id")]

        public int Id { get; set; }
        [ForeignKey("Rid")]
        public int Rid { get; set; }
        public int Quantity { get; set; }
     
        public DateTime ordate { get; set; }
        [NotMapped]
        public string? Name { get; set; }
        [NotMapped]

        public decimal Price { get; set; }
        [NotMapped]

        public string? ImageUrl { get; set; }

    }
}
