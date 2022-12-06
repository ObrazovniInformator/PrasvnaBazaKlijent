namespace PrasvnaBazaKlijent.Models
{
    public class PrimeriKnjizenja
    {
        public PrimeriKnjizenja()
        {

        }
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Podnaslov { get; set; }
        public string Napomena { get; set; }
        public string Tekst { get; set; }
        public int IdRubrikaPK { get; set; }
        public RubrikaPK IdRubrkaPKNavigation { get; set; }
    }
}
