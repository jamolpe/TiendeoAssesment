using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Models
{
    public class StoreDto : LocalDto
    {
        public string Name { get; set; }
        public int RankPosition { get; set; }
        public int Business { get; set; }
    }
}
