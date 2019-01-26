using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoAPI.Models;

namespace TiendeoAPI.Core.Interfaces
{
    public interface IServiceCore
    {
        List<ServiceModel> GetAllServicesFromACity(string city);

    }
}
