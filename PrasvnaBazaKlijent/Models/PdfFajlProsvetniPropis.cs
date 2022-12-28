namespace PrasvnaBazaKlijent.Models
{
    public class PdfFajlProsvetniPropis
    {
        public int Id { get; set; }
        public string NaslovPdf { get; set; }
        public string PdfPath { get; set; }
        public int IdProsvetniPropis { get; set; }
        public ProsvetniPropis IdProsvetniPropisNavigation { get; set; }
    }
}
