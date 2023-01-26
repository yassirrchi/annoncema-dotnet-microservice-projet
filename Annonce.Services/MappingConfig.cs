
using Annonce.Services.Models;
using Annonce.Services.Models.Dto;
using AutoMapper;

namespace Artisanal.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
          var mappingConfig = new MapperConfiguration(config =>

              {
                  config.CreateMap<AnnonceDto, Annonces>();
                  config.CreateMap<Annonces, AnnonceDto>();
              }

              );


            return mappingConfig;

        }
    }
}
