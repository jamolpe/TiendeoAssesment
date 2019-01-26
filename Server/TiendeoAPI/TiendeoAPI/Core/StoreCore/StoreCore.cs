using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Interfaces;
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

            return resultStores.OrderBy(x => x.RankPosition).ToList();
        }

        public StoreModel GetNearestStoreFromCoords(Coord userCoord)
        {
            var stores = this._localService.GetAllStores();
            StoreDistanceModel distanceModel = new StoreDistanceModel();
            stores.ForEach(store =>
            {
                Coord storeCoord = new Coord {Lat = store.Lat, Lon = store.Lon};
                var distance = DistanceCalculate.CalculateDistanceBetween(userCoord, storeCoord);
                if (distanceModel.Store == null || distanceModel.Distance > distance)
                {
                    var storeModel = Mapper.Map<StoreModel>(store);
                    var businessModel = this._businessService.GetBusinessById(store.BusinessId);
                    var cityModel = this._cityService.GetCityById(store.CityId);
                    storeModel.Business = (businessModel != null) ? Mapper.Map<BusinessModel>(businessModel) : null;
                    storeModel.City = (cityModel != null) ? Mapper.Map<CityModel>(cityModel) : null;

                    distanceModel.Distance = distance;
                    distanceModel.Store = storeModel;

                }
            });

            return distanceModel.Store;
        }
    }
}