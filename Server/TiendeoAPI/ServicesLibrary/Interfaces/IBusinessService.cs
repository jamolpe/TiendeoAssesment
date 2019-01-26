using System.Collections.Generic;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    public interface IBusinessService
    {
        List<BusinessDto> GetBusiness();
        BusinessDto GetBusinessById(int id);
    }
}
