using System.Collections.Generic;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.Interfaces
{
    public interface IStoreCore
    {
        List<StoreModel> GetStoresOrderByRank();
        StoreDistanceModel GetNearestStoreFromCoords(Coord userCoord);
        List<StoreDistanceModel> GetXNearestStoresFromCoords(Coord userCoord, int number);

    }
}
