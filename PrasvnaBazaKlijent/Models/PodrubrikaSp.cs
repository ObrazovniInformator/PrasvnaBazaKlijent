using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class PodrubrikaSp
    {
        public PodrubrikaSp()
        {
            PodpodrubrikaSp = new HashSet<PodpodrubrikaSp>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdRubrika { get; set; }

        public RubrikaSp IdRubrikaNavigation { get; set; }
        public ICollection<PodpodrubrikaSp> PodpodrubrikaSp { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
