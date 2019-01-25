using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers.Mappers
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper(ICityService cityService)
        {
            CreateMap<ServiceDto, ServiceModel>().AfterMap((source, destination, context) =>
                destination.City = context.Mapper.Map<CityModel>(cityService.GetCityById(source.Id)));
        }
    }
}
