using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers.Mappers
{
    public class StoreMapper : Profile
    {
        public StoreMapper()
        {
            CreateMap<StoreDto, StoreModel>();
        }
    }
}
