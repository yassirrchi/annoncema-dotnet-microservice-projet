using Annonce.Services.Models.Dto;

namespace Annonce.Services.Repository
{
    public interface IAnnonceRepository
    {
        Task<IEnumerable<AnnonceDto>> GetAnnonces();
        Task<AnnonceDto> GetAnnonceById(int annonceId);
        Task<AnnonceDto> CreateUpdateAnnonce(AnnonceDto annonceDto);
        Task<bool> DeleteAnnonce(int annoceId);
    }
}
