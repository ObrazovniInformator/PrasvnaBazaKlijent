﻿using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class PodrubrikaPP
    {
        public PodrubrikaPP()
        {
            ProsvetniPropis = new HashSet<ProsvetniPropis>();
        }

        public int ID { get; set; }
        public string NazivPodrubrike { get; set; }
        public int IdRubrika { get; set; }

        public RubrikaPP IdRubrikaNavigation { get; set; }
        public ICollection<ProsvetniPropis> ProsvetniPropis { get; set; }
    }
}
