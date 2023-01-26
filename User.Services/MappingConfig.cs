

using AutoMapper;
using User.Services.Models;
using User.Services.Models.Dto;

namespace Artisanal.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
          var mappingConfig = new MapperConfiguration(config =>

              {
                  config.CreateMap<UserDto, Users>();
                  config.CreateMap<Users, UserDto>();
              }

              );


            return mappingConfig;

        }
    }
}
