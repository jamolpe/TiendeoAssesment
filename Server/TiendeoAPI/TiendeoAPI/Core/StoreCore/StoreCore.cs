﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using TiendeoAPI.Core.Interfaces;
using TiendeoAPI.Helpers;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.StoreCore
{
    public class StoreCore : IStoreCore
    {
        private readonly ILocalService _localService;
        private readonly IBusinessService _businessService;
        private readonly ICityService _cityService;

        public StoreCore(ILocalService localService, IBusinessService businessService, ICityService cityService)
        {
            this._localService = localService;
            this._businessService = businessService;
            this._cityService = cityService;
        }

        public List<StoreModel> GetStoresOrderByRank()
        {
            return this.GetStores().OrderBy(x => x.Rank).ToList();
        }

        private List<StoreModel> GetStores()
        {
            List<StoreModel> resultStores = new List<StoreModel>();
            var storesDtos = this._localService.GetAllStores();

            storesDtos.ForEach(store =>
            {
                var storeModel = Mapper.Map<StoreModel>(store);
                var businessDto = this._businessService.GetBusinessById(store.BusinessId);
                var cityDto = this._cityService.GetCityById(store.CityId);
                storeModel.Business = (businessDto != null) ? Mapper.Map<BusinessModel>(businessDto) : null;
                storeModel.City = (cityDto != null) ? Mapper.Map<CityModel>(cityDto) : null;
                resultStores.Add(storeModel);
            });
            return resultStores;
        }

        public List<StoreModel> GetXStoresFromCityOrderByRank(string name,int number)
        {
            var city = this._cityService.GetCityByName(name);
            if(city != null)
            {
                return this.GetStores().Where(store => store.City.Name == name).Take(number).OrderBy(x => x.Rank).ToList();
            }
            else
            {
                return null;
            }
        }

        public StoreDistanceModel GetNearestStoreFromCoords(Coord userCoord)
        {
            var storesDtos = this._localService.GetAllStores();
            StoreDistanceModel distanceModel = new StoreDistanceModel();
            storesDtos.ForEach(store =>
            {
                var distance = this.GetDistanceToStore(userCoord, store);
                if (distanceModel.Store == null || distanceModel.Distance > distance)
                {
                    this.SetStoreDistanceModelFromStoreDto(store, distanceModel);
                    distanceModel.Distance = distance;
                }
            });

            return distanceModel;
        }

        public List<StoreDistanceModel> GetXNearestStoresFromCoords(Coord userCoord, int number)
        {
            var storesDtos = this._localService.GetAllStores();
            List<StoreDistanceModel> distanceModels = new List<StoreDistanceModel>();

            storesDtos.ForEach(store =>
            {
                StoreDistanceModel storeDistanceModel = new StoreDistanceModel();
                var distance = this.GetDistanceToStore(userCoord, store);
                this.SetStoreDistanceModelFromStoreDto(store, storeDistanceModel);
                storeDistanceModel.Distance = distance;
                distanceModels.Add(storeDistanceModel);
            });

            return distanceModels.OrderBy(s => s.Distance).Take(number).ToList();
        }

        private double GetDistanceToStore(Coord userCoord, StoreDto store)
        {
            Coord storeCoord = new Coord { Lat = store.Lat, Lon = store.Lon };
            return DistanceCalculate.CalculateDistanceBetween(userCoord, storeCoord);
        }

        private void SetStoreDistanceModelFromStoreDto(StoreDto store, StoreDistanceModel distanceModel)
        {
            var storeModel = Mapper.Map<StoreModel>(store);
            var businessDto = this._businessService.GetBusinessById(store.BusinessId);
            var cityDto= this._cityService.GetCityById(store.CityId);
            storeModel.Business = (businessDto != null) ? Mapper.Map<BusinessModel>(businessDto) : null;
            storeModel.City = (cityDto != null) ? Mapper.Map<CityModel>(cityDto) : null;
            distanceModel.Store = storeModel;
        }

       
    }
}