using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServicesLibrary.Helpers;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public class LocalService: ILocalService
    {
        private readonly DataContext _context;

        public LocalService(DataContext context)
        {
            this._context = context;
        }

        public List<ServiceDto> GetAllServices()
        {
            return this._context.Services.ToList();
        }

        public List<StoreDto> GetAllStores()
        {
            return this._context.Stores.ToList();
        }

        public List<StoreDto> GetAllStoresOrderedByRank()
        {
            return this._context.Stores.OrderBy(x => x.RankPosition).ToList();
        }

    }
}
