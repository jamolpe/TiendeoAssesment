using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace ServicesLibrary.Helpers.Mocker
{
    public class DatabaseMocker : IDatabaseMocker
    {
        private readonly DataContext _dataContext;
        private JsonData _jsonData = new JsonData();
        private int _lastLocalId = 1;
        private class JsonData
        {
            [JsonProperty("cities")]
            public List<CityJson> Cities { get; set; }
            [JsonProperty("Business")]
            public List<BusinessJson> Business { get; set; }
            [JsonProperty("Stores")]
            public List<StoresJson> Stores { get; set; }
            [JsonProperty("Services")]
            public List<ServicesJson> Services { get; set; }
            public int count { get; set; }
        }

        private class CityJson
        {
            public int Id { get; set; }
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Province")]
            public string Province { get; set; }
            [JsonProperty("Lon")]
            public Double Lon { get; set; }
            [JsonProperty("Lat")]
            public Double Lat { get; set; }
            [JsonProperty("Rank")]
            public int Rank { get; set; }
        }

        private class BusinessJson
        {
            public int Id { get; set; }
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Rank")]
            public int Rank { get; set; }
            [JsonProperty("Marker")]
            public string Marker { get; set; }
        }

        private class StoresJson
        {
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Adress")]
            public string Adress { get; set; }
            [JsonProperty("City")]
            public string City { get; set; }
            [JsonProperty("Lon")]
            public Double Lon { get; set; }
            [JsonProperty("Lat")]
            public Double Lat { get; set; }
            [JsonProperty("Business")]
            public string Business { get; set; }
            [JsonProperty("Rank")]
            public int Rank { get; set; }

        }

        private class ServicesJson
        {
            [JsonProperty("ServiceType")]
            public string ServiceType { get; set; }
            [JsonProperty("Adress")]
            public string Adress { get; set; }
            [JsonProperty("City")]
            public string City { get; set; }
            [JsonProperty("Lon")]
            public Double Lon { get; set; }
            [JsonProperty("Lat")]
            public Double Lat { get; set; } 
        }


        private void LoadData()
        {
            using (StreamReader r = new StreamReader("Data.json"))
            {
                string json = r.ReadToEnd();
                this._jsonData = JsonConvert.DeserializeObject<JsonData>(json);
            }
        }

        public DatabaseMocker(DataContext dataContext)
        {
            this.LoadData();
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
            var id = 1;
            this._jsonData.Business.ForEach(b =>
            {
                b.Id = id;
                var dto = new BusinessDto {Id = b.Id, Marker = b.Marker,Name = b.Name, Rank = b.Rank};
                this._dataContext.Business.AddAsync(dto);
                id++;
            });

            //var businessOne = new BusinessDto {Id = 1, Name = "El Corte Ingles", Rank = 1,Marker = "https://static0.tiendeo.com/upload_negocio/negocio_43/marker.png"};
            //var businessTwo = new BusinessDto {Id = 2, Name = "Carrefour", Rank = 2, Marker = "https://static0.tiendeo.com/upload_negocio/negocio_36/marker.png" };
            //var businessThree = new BusinessDto {Id = 3, Name = "Lidl", Rank = 3, Marker = "https://static0.tiendeo.com/upload_negocio/negocio_110/marker.png" };
            //this._dataContext.Business.AddAsync(businessOne);
            //this._dataContext.Business.AddAsync(businessTwo);
            //this._dataContext.Business.Add(businessThree);
        }

        private void CreateCitiesData()
        {
            var id = 1;
            this._jsonData.Cities.ForEach(c =>
            {
                c.Id = id;
                var city = new CityDto
                    {Id = c.Id, Lat = c.Lat, Lon = c.Lon, Name = c.Name, Province = c.Province, Rank = c.Rank};
                this._dataContext.Cities.AddAsync(city);
                id++;
            });

            //var cityOne = new CityDto
            //    {Id = 1, Lat = 40.4203, Lon = -3.705774, Name = "Madrid", Province = "Madrid", Rank = 1};
            //var cityTwo = new CityDto
            //    {Id = 2, Lat = 41.38559, Lon = 2.168745, Name = "Barcelona", Province = "Barcelona", Rank = 1};
            //this._dataContext.Cities.AddAsync(cityOne);
            //this._dataContext.Cities.AddAsync(cityTwo);

        }

        private void CreateServicesData()
        {
            this._jsonData.Services.ForEach(s =>
            {
                var city = this._jsonData.Cities.Find(c => c.Name == s.City);
                if (city != null)
                {
                    var cityId = city.Id;
                    var type = 0;
                    switch (s.ServiceType)
                    {
                        case "Cajero":
                            type = 2;
                            break;
                        case "Lavabo":
                            type = 1;
                            break;
                        case "Punto de información":
                            type = 0;
                            break;
                        case "Punto de recogida":
                            type = 3;
                            break;
                    }

                    var service = new ServiceDto
                    {
                        Id = this._lastLocalId,
                        Adress = s.Adress,
                        CityId = cityId,
                        Lat = s.Lat,
                        Lon = s.Lon,
                        ServiceType = type
                    };
                    this._dataContext.Services.AddAsync(service);
                    this._lastLocalId++;
                }
                
            });

            //var serviceOne = new ServiceDto
            //    {Id = 1, Adress = "GRAN VIA CORTS CATALANES, 536", Lat = 41.38252, Lon = 2.15953135, ServiceType = 1,CityId = 2};
            //var serviceTwo = new ServiceDto
            //    {Id = 2, Adress = "AV.DE MADRID, 92", Lat = 41.37833, Lon = 2.127494, ServiceType = 1,CityId = 2};
            //this._dataContext.Services.AddAsync(serviceOne);
            //this._dataContext.Services.AddAsync(serviceTwo);
        }

        private void CreateStoresData()
        {
            this._jsonData.Stores.ForEach(s =>
            {
                var business = this._jsonData.Business.Find(b => b.Name == s.Business);
                var city = this._jsonData.Cities.Find(c => c.Name == s.City);
                if (business != null && city != null)
                {
                    var businessId = business.Id;
                    var cityId = city.Id;
                    var store = new StoreDto
                    {
                        Adress = s.Adress,
                        BusinessId = businessId,
                        CityId = cityId,
                        Id = this._lastLocalId,
                        Lat = s.Lat,
                        Lon = s.Lon,
                        Name = s.Name,
                        RankPosition = s.Rank
                    };
                    this._dataContext.Stores.AddAsync(store);
                    this._lastLocalId++;
                }
            });

            //var storeMockOne = new StoreDto
            //{
            //    Id = 1,
            //    Name = "Carrefour Madrid Sur",
            //    Lat = 40.3809929,
            //    Lon = -3.663251,
            //    Adress = "Avenida de Pablo Neruda, 91-97",
            //    RankPosition = 1,
            //    BusinessId = 2,
            //    CityId = 1
            //};
            //var storeMockTwo = new StoreDto
            //{
            //    Id = 2,
            //    Name = "Carrefour Aluche",
            //    Lat = 40.38641,
            //    Lon = -3.764148,
            //    Adress = "Avda. de los Poblados, 58",
            //    RankPosition = 1,
            //    BusinessId = 2,
            //    CityId = 1
            //};
            //this._dataContext.Stores.AddAsync(storeMockOne);
            //this._dataContext.Stores.AddAsync(storeMockTwo);
        }
    }
}