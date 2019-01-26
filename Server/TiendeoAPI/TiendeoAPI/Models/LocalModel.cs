namespace TiendeoAPI.Models
{
    public class LocalModel
    {
          public double Lon { get; set; }
          public double Lat { get; set; }
          public string Adress { get; set; }
          public CityModel City { get; set; }
    }
}
