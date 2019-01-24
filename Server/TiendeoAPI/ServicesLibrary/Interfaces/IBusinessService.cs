using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServicesLibrary.Helpers;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    public interface IBusinessService
    {
        List<BusinessDto> GetBusiness();
    }
}
