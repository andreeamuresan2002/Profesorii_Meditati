namespace Profesorii_Meditati.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Rol { get; set; } // Admin, Profesor, Student
    }
}
