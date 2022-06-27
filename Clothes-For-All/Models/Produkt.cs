namespace Clothes_For_All.Models
{
    public class Produkt
    {
        
        
        public long Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public string Farve { get; set; }
        public string Størrelse { get; set; }
        public string BilledURL { get; set; }
        public decimal Pris { get; set; }
        
        public int ProduktTypeId { get; set; }

        public int KategoriId { get; set; }


    }
}
