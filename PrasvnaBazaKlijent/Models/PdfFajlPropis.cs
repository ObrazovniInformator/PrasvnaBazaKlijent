namespace PrasvnaBazaKlijent.Models
{
    public class PdfFajlPropis
    {
        public int Id { get; set; }
        public string NaslovPdf { get; set; }
        public string PdfPath { get; set; }
        public int IdPropis { get; set; }
        public Propis IdPropisNavigation { get; set; }
    }
}
