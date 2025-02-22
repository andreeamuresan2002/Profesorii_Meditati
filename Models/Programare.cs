namespace Profesorii_Meditati.Models
{
    public class Programare
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int MeditatieId { get; set; }
        public DateTime Data { get; set; }
        public string Stare { get; set; }
    }
}
