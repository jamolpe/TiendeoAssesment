using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Models
{
    public class CityDto
    {
        public string name { get; set; }
        public string province { get; set; }
        public Double Long { get; set; }
        public Double Lat { get; set; }
        public int Rank { get; set; }
    }
}
