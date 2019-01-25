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
    public class StoreMapper : Profile
    {
        public StoreMapper(ICityService cityService,IBusinessService businessService)
        {
            CreateMap<StoreDto, StoreModel>().AfterMap((source, destination, context) =>
                {
                    destination.City = context.Mapper.Map<CityModel>(cityService.GetCityById(source.Id));
                    destination.Business =
                        context.Mapper.Map<BusinessModel>(businessService.GetBusinessById(source.Id));
                });
        }
    }
}
