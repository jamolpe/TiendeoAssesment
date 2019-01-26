using System.Collections.Generic;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
   public interface ILocalService
   {
       List<ServiceDto> GetAllServices();

       List<StoreDto> GetAllStores();

   }
}
