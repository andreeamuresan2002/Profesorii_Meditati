namespace Profesorii_Meditati.Models
{
    public class Recenzie
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProfesorId { get; set; }
        public int Rating { get; set; } // 1-5 stele
        public string Comentariu { get; set; }
    }
}
