using AutoMapper;
using ServicesLibrary.Models;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers.Mappers
{
    public class BusinessMapper: Profile
    {
        public BusinessMapper()
        {
            CreateMap<BusinessDto, BusinessModel>();
        }
    }
}
