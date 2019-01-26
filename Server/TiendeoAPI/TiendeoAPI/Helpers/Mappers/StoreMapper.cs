using AutoMapper;
using ServicesLibrary.Models;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers.Mappers
{
    public class StoreMapper : Profile
    {
        public StoreMapper()
        {
            CreateMap<StoreDto, StoreModel>();
        }
    }
}
