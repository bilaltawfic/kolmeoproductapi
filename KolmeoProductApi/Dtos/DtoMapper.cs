using AutoMapper;
using KolmeoProductApi.Dtos.MappingProfiles;

namespace KolmeoProductApi.Dtos
{
    public class DtoMapper
    {
        /// <summary>
        /// Create a mapper that maps Models to Dtos and vice versa.
        /// </summary>
        /// <returns>A mapper configured to map Models to Dtos and vice versa.</returns>
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<ProductMappingProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
