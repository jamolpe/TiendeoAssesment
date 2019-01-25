using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public Double Long { get; set; }
        public Double Lat { get; set; }
        public int Rank { get; set; }
    }
}
