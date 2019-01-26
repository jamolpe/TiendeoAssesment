using System.Collections.Generic;
using System.Linq;
using ServicesLibrary.Helpers;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public class CityService: ICityService
    {
        private readonly DataContext _context;

        public CityService(DataContext context)
        {
            this._context = context;
        }

        public List<CityDto> GetCities()
        {
            return this._context.Cities.ToList();
        }

        public CityDto GetCityById(int id)
        {
            return this._context.Cities.FirstOrDefault(c => c.Id == id);
        }

        public CityDto GetCityByName(string name)
        {
            return this._context.Cities.FirstOrDefault(x => x.Name == name);
        }

    }
}
