using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class RubrikaSp
    {
        public RubrikaSp()
        {
            PodrubrikaSp = new HashSet<PodrubrikaSp>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<PodrubrikaSp> PodrubrikaSp { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
