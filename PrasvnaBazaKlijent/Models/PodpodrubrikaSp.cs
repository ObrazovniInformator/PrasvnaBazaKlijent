using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class PodpodrubrikaSp
    {
        public PodpodrubrikaSp()
        {
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodrubrika { get; set; }

        public PodrubrikaSp IdPodrubrikaNavigation { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
