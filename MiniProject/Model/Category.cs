using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        public string? Cname { get; set; }
    }
}
