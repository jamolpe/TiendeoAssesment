
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ServicesLibrary.Interfaces;
using TiendeoAPI.Core.Interfaces;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.CityCore
{
    public class CityCore : ICityCore
    {
        private readonly ICityService _cityService;
        public CityCore(ICityService cityService)
        {
            this._cityService = cityService;
        }

        public CityModel GetCityByName(string name)
        {
            var cityDto = this._cityService.GetCityByName(name);
            return (cityDto != null) ? Mapper.Map<CityModel>(cityDto) : null;

        }

        public List<CityModel> GetCities()
        {
            List<CityModel> citiesResult = new List<CityModel>();
            var cities = this._cityService.GetCities();
            if (cities != null && cities.Any())
                cities.ForEach(city =>
                {
                    citiesResult.Add(Mapper.Map<CityModel>(city));
                });

            return citiesResult;
        }
    }
}