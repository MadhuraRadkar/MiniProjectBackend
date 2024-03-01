using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string? ImageUrl { get; set; }
        [Required]
        [ForeignKey("Cid")]
        public int Cid { get; set; }
        [NotMapped]
        public string? Cname {  get; set; }
       


    }
}
