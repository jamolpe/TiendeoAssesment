using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServicesLibrary.Helpers;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public class BusinessService :IBusinessService
    {
        private readonly DataContext _context;

        public BusinessService(DataContext context)
        {
            this._context = context;
        }

        public List<BusinessDto> GetBusiness()
        {
            return this._context.Business.ToList();
        }
    }
}
