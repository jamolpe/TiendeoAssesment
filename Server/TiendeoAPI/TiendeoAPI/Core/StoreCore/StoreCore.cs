using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Interfaces;
using TiendeoAPI.Core.Interfaces;
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
    }
}