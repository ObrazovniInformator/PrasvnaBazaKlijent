using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class Podrubrika
    {
        public Podrubrika()
        {
            Propis = new HashSet<Propis>();
        }

        public int Id { get; set; }
        public string NazivPodrubrike { get; set; }
        public int? IdRubrika { get; set; }

        public Rubrika IdRubrikaNavigation { get; set; }
        public ICollection<Propis> Propis { get; set; }
    }
}
