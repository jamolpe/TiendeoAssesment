using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServicesLibrary.Helpers;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace ServicesLibrary.Mocker
{
    public class DatabaseMocker : IDatabaseMocker
    {
        private DataContext _dataContext;

        public DatabaseMocker(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Seed()
        {
            CreateBusinessData();
            CreateCitiesData();
            CreateServicesData();
            CreateStoresData();
            this._dataContext.SaveChanges();
        }

        private void CreateBusinessData()
        {
            var businessOne = new BusinessDto {Id = 1, Name = "El Corte Ingles", Rank = 1};
            var businessTwo = new BusinessDto {Id = 2, Name = "Carrefour", Rank = 2};
            var businessThree = new BusinessDto {Id = 3, Name = "Lidl", Rank = 3};
            this._dataContext.Business.AddAsync(businessOne);
            this._dataContext.Business.AddAsync(businessTwo);
            this._dataContext.Business.AddAsync(businessThree);
        }

        private void CreateCitiesData()
        {
            var cityOne = new CityDto
                {Id = 1, Lat = 40.4203, Long = -3.705774, Name = "Madrid", Province = "Madrid", Rank = 1};
            var cityTwo = new CityDto
                {Id = 2, Lat = 41.38559, Long = 2.168745, Name = "Barcelona", Province = "Barcelona", Rank = 1};
            this._dataContext.Cities.AddAsync(cityOne);
            this._dataContext.Cities.AddAsync(cityTwo);

        }

        private void CreateServicesData()
        {
            var serviceOne = new ServiceDto
                {Id = 1, Adress = "GRAN VIA CORTS CATALANES, 536", Lat = 41.38252, Long = 2.15953135, ServiceType = 1};
            var serviceTwo = new ServiceDto
                {Id = 2, Adress = "AV.DE MADRID, 92", Lat = 41.37833, Long = 2.127494, ServiceType = 1};
            this._dataContext.Services.AddAsync(serviceOne);
            this._dataContext.Services.AddAsync(serviceTwo);
        }

        private void CreateStoresData()
        {
            var storeMockOne = new StoreDto
            {
                Id = 1,
                Name = "Carrefour Madrid Sur",
                Lat = 40.3809929,
                Long = -3.663251,
                Adress = "Avenida de Pablo Neruda, 91-97",
                RankPosition = 1,
                Business = 1
            };
            var storeMockTwo = new StoreDto
            {
                Id = 2,
                Name = "Carrefour Aluche",
                Lat = 40.38641,
                Long = -3.764148,
                Adress = "Avda. de los Poblados, 58",
                RankPosition = 1,
                Business = 1
            };
            this._dataContext.Stores.AddAsync(storeMockOne);
            this._dataContext.Stores.AddAsync(storeMockTwo);
        }
    }
}