using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Interfaces;
using TiendeoAPI.Core.Interfaces;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.ServiceCore
{
    public class ServiceCore : IServiceCore
    {
        private readonly ILocalService _localService;
        private readonly ICityService _cityService;
        public ServiceCore(ILocalService localService,ICityService cityService)
        {
            this._localService = localService;
            this._cityService = cityService;
        }
        public List<ServiceModel> GetAllServicesFromACity(string city)
        {
            List<ServiceModel> serviceModels = new List<ServiceModel>();
            var cityDto = this._cityService.GetCityByName(city);
            if (cityDto != null)
            {
                var serviceDtos = this._localService.GetAllServices().Where(s => s.CityId == cityDto.Id).ToList();
                if (serviceDtos.Any())
                {
                    serviceDtos.ForEach(s =>
                    {
                        var serviceModel = Mapper.Map<ServiceModel>(s);
                        var cityModel = Mapper.Map<CityModel>(cityDto);
                        serviceModel.City = cityModel;
                        serviceModels.Add(serviceModel);
                    });

                }
            }

            return serviceModels;
        }
    }
}