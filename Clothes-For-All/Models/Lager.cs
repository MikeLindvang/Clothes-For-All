namespace Clothes_For_All.Models
{
    public class Lager
    {
        public long id { get; set; }
        public long produktId { get; set; }
        public long supplierId { get; set; }
        public int beholdning { get; set; }
    }
}
