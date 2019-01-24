using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Models
{
    public abstract class LocalDto
    {
          public double Long { get; set; }
          public double Lat { get; set; }
          public string Adress { get; set; }

    }
}
