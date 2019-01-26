using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers.Mappers
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<ServiceDto, ServiceModel>();
        }
    }
}
