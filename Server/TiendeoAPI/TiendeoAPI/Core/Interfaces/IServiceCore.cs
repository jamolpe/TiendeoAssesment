using System.Collections.Generic;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.Interfaces
{
    public interface IServiceCore
    {
        List<ServiceModel> GetAllServicesFromACity(string city);

    }
}
