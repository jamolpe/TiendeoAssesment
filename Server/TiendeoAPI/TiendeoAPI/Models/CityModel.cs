using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoAPI.Models
{
    public class CityModel
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public Double Lon { get; set; }
        public Double Lat { get; set; }
        public int Rank { get; set; }
    }
}
