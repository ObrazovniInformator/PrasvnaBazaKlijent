using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class CasopisNaslov
    {
        public CasopisNaslov()
        {
            PropisCasopis = new HashSet<PropisCasopis>();
            PdfFajlCasopis = new HashSet<PdfFajlCasopis>();
        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public string DatumObjavljivanja { get; set; }
        public string Autor { get; set; }
        public int? IdOznaka { get; set; }
        public CasopisOznaka IdCasopisOznakaNavigation { get; set; }
        public int? IdGodina { get; set; }
        public CasopisGodina IdCasopisGodinaNavigation { get; set; }
        public int? IdBroj { get; set; }
        public CasopisBroj IdCasopisBrojNavigation { get; set; }
        public int? IdRubrika { get; set; }
        public RubrikaCasopis IdRubrikaCasopisNavigation { get; set; }
        public int? IdOblast { get; set; }
        public int? IdPodrubrika { get; set; }
        public PodrubrikaCasopis IdPodrubrikaCasopisNavigation { get; set; }

        public ICollection<PropisCasopis> PropisCasopis { get; set; }
        public ICollection<PdfFajlCasopis> PdfFajlCasopis { get; set; }

        public static void DodajCasopis(CasopisNaslov casopis)
        {
            obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
            _context.CasopisNaslov.Add(casopis);
            _context.SaveChanges();
        }
    }
}

