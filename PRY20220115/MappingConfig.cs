using AutoMapper;
using PRY20220115.Models;
using PRY20220115.Models.Dto;

namespace PRY20220115
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PasajeroDto, Pasajero>();
                config.CreateMap<Pasajero, PasajeroDto>();
            });

            return mappingConfig;
        }
    }
}
