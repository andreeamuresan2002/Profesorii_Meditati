namespace Profesorii_Meditati.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Materie { get; set; } // Matematică, Fizică, Engleză etc.
        public int ExperientaAni { get; set; }
        public string Descriere { get; set; }
    }
}
