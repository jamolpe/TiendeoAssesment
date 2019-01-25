using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Models;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<CityDto, CityModel>();

        }
    }
}
