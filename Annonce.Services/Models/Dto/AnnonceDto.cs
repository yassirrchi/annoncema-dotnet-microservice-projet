namespace Annonce.Services.Models.Dto
{
    public class AnnonceDto
    {
       
        public int AnnonceId { get; set; }
        
        public string title { get; set; }
   
        public double Price { get; set; }
        public string desc { get; set; }

        public bool Premuim { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }

        public byte[] Image { get; set; }

    }
}
