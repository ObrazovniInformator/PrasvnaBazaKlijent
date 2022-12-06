namespace PrasvnaBazaKlijent.Models
{
    public partial class Pretplatnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pib { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string MaticniBroj { get; set; }
        public string Pretplata { get; set; }
        public string DatumPocetkaPretplate { get; set; }
        public string DatumKrajaPretplate { get; set; }
    }
}
