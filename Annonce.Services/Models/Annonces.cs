


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Annonce.Services.Models
{
    [Table("Annonces")]
    public class Annonces
    {
        [Key]
        public int AnnonceId { get; set; }
        [Required]
        public string title { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public bool Premuim { get; set; }
        public byte[] Image { get; set; }

    }
}
