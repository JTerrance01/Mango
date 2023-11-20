using AutoMapper;
using Mango.Services.AuthAPI;

namespace Mango.Services.AuthAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<>();
                //config.CreateMap<>();
            });

            return mappingConfig;
        }
    }
}
