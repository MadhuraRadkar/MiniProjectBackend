using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("Id")]
        public int Id { get; set; }
        [ForeignKey("Rid")]
        public int Rid { get; set; }
        public int Qty { get; set; }
        [NotMapped]
        public string? Name { get; set; }
        [NotMapped]

        public decimal Price { get; set; }
        [NotMapped]

        public string? ImageUrl { get; set; }

    }
}
