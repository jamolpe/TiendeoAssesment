using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.Interfaces
{
    public interface IStoreCore
    {
        List<StoreModel> GetStoresOrderByRank();
        StoreModel GetNearestStoreFromCoords(Coord userCoord);
    }
}
