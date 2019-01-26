using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<StoreModel> resultStores = new List<StoreModel>();
            var stores = this._localService.GetAllStores();

            stores.ForEach(store =>
            {
                var storeModel = Mapper.Map<StoreModel>(store);
                var businessModel = this._businessService.GetBusinessById(store.BusinessId);
                var cityModel = this._cityService.GetCityById(store.CityId);
                storeModel.Business = (businessModel != null) ? Mapper.Map<BusinessModel>(businessModel) : null;
                storeModel.City = (cityModel != null) ? Mapper.Map<CityModel>(cityModel) : null;
                resultStores.Add(storeModel);
            });

            return resultStores.OrderBy(x => x.Rank).ToList();
        }

        public StoreDistanceModel GetNearestStoreFromCoords(Coord userCoord)
        {
            var stores = this._localService.GetAllStores();
            StoreDistanceModel distanceModel = new StoreDistanceModel();
            stores.ForEach(store =>
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
            var stores = this._localService.GetAllStores();
            List<StoreDistanceModel> distanceModels = new List<StoreDistanceModel>();

            stores.ForEach(store =>
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
            var businessModel = this._businessService.GetBusinessById(store.BusinessId);
            var cityModel = this._cityService.GetCityById(store.CityId);
            storeModel.Business = (businessModel != null) ? Mapper.Map<BusinessModel>(businessModel) : null;
            storeModel.City = (cityModel != null) ? Mapper.Map<CityModel>(cityModel) : null;
            distanceModel.Store = storeModel;
        }

       
    }
}