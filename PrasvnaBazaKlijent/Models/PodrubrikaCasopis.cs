using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class PodrubrikaCasopis
    {
        public PodrubrikaCasopis()
        {
            CasopisNaslov = new HashSet<CasopisNaslov>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int IdRubrika { get; set; }
        public RubrikaCasopis IdRubrikaNavigation { get; set; }

        public ICollection<CasopisNaslov> CasopisNaslov { get; set; }
    }
}
