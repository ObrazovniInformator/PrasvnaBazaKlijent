using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class RubrikaCasopis
    {
        public RubrikaCasopis()
        {
            PodrubrikaCasopis = new HashSet<PodrubrikaCasopis>();
            CasopisNaslov = new HashSet<CasopisNaslov>();
        }
        public int ID { get; set; }
        public string NazivRubrike { get; set; }
        public int IdOblast { get; set; }
        public int? IdBroj { get; set; }
        public CasopisBroj IdCasopisBrojNavigation { get; set; }
        public ICollection<CasopisNaslov> CasopisNaslov { get; set; }
        public ICollection<PodrubrikaCasopis> PodrubrikaCasopis { get; set; }
    }
}