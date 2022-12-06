using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class Vest
    {
        public Vest()
        {
            PropisVest = new HashSet<PropisVest>();
        }
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sazetak { get; set; }
        public string Tekst { get; set; }
        public string DanUNedelji { get; set; }
        public int DanUMesecu { get; set; }
        public int Mesec { get; set; }
        public int Godina { get; set; }
        public int IdRubrikaVesti { get; set; }
        public int? IdKategorija { get; set; }
        public VestiKategorija IdKategorijaNavigation { get; set; }

        public RubrikaVesti IdRubrikeVestiNavigation { get; set; }
        public ICollection<PropisVest> PropisVest { get; set; }
    }
}
