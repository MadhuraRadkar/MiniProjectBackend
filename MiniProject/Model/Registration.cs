using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int Rid { get; set; }
      
        public string? UserName { get; set; }
     
        public string? Password { get; set; }
   
        public string? Email { get; set; }
      
        public string? PhoneNumber { get; set; }
        
        public int RoleId { get; set; }
        [NotMapped]
        public string? Token {  get; set; }

    }
}
