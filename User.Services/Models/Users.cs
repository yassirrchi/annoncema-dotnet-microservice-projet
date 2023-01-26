using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Services.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required, StringLength(25)]
        public string UserName { get; set; }
        [Range(1, 1000)]
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
      

    }
}
