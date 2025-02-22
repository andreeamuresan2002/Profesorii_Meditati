namespace Profesorii_Meditati.Models
{
    public class Meditatie
    {
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public string Materie { get; set; }
        public string Descriere { get; set; }
        public int Durata { get; set; } // în minute
        public decimal Pret { get; set; }
    }
}
