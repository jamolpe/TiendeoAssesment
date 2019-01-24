using System;
using System.Collections.Generic;
using System.Text;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
   public interface ILocalService
   {
       List<ServiceDto> GetAllServices();

       List<StoreDto> GetAllStores();
   }
}
