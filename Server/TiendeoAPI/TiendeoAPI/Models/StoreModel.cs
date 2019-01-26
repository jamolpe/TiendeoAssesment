namespace TiendeoAPI.Models
{
    public class StoreModel : LocalModel
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public BusinessModel Business { get; set; }

    }
}
