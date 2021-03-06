﻿using System.Collections.Generic;
using System.Linq;
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

        public BusinessDto GetBusinessById(int id)
        {
            return this._context.Business.FirstOrDefault(b => b.Id == id);
        }
    }
}
