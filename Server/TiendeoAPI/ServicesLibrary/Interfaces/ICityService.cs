using System.Collections.Generic;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    public interface ICityService
    {
       
       List<CityDto> GetCities();
       CityDto GetCityById(int id);
       CityDto GetCityByName(string name);

    }
}
