using Annonce.Services.DbContexts;
using Annonce.Services.Models;
using Annonce.Services.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Annonce.Services.Repository
{
   
    public class AnnonceRepository : IAnnonceRepository
    {
        private readonly ApplicationDbContext _db;

        private IMapper _mapper;











        public AnnonceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AnnonceDto> CreateUpdateAnnonce(AnnonceDto annonceDto)
        {
            Annonces annonce = _mapper.Map<AnnonceDto, Annonces>(annonceDto);
            if (annonce.AnnonceId > 0)
            {
                _db.Annonces.Update(annonce);
            }
            else
            {
                _db.Annonces.Add(annonce);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Annonces, AnnonceDto>(annonce);
        }

        public async Task<bool> DeleteAnnonce(int annonceId)
        {
            try
            {
                Annonces annonce = await _db.Annonces.FirstOrDefaultAsync(u => u.AnnonceId == annonceId);
                if (annonce == null)
                {
                    return false;
                }
                _db.Annonces.Remove(annonce);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<AnnonceDto> GetAnnonceById(int annonceId)
        {
            Annonces annonce = await _db.Annonces.Where(x => x.AnnonceId == annonceId).FirstOrDefaultAsync();
            
            return _mapper.Map<AnnonceDto>(annonce);
        }






        public async Task<IEnumerable<AnnonceDto>> GetAnnonces()
        {
            List<Annonces> annonceList = await _db.Annonces.ToListAsync();

           
            return _mapper.Map<List<AnnonceDto>>(annonceList);

        }
    }
}
