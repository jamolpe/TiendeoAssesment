﻿using System;
using System.Collections.Generic;
using System.Text;
using TiendeoAPI.Helpers.enums;

namespace TiendeoAPI.Models
{
    class ServiceModel : LocalModel
    {
        public ServiceTypes ServiceType { get; set; }
    }
}