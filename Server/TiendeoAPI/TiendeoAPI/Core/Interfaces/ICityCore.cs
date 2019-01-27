using System;
using System.Collections.Generic;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.Interfaces
{
    public interface ICityCore
    {
        CityModel GetCityByName(string name);
        List<CityModel> GetCities();

    }

}
