using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoAPI.Models
{
    public class StoreModel : LocalModel
    {
        public string Name { get; set; }
        public int RankPosition { get; set; }
    }
}
