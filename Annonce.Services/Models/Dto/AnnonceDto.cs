namespace Annonce.Services.Models.Dto
{
    public class AnnonceDto
    {
       
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
   
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }

    }
}
