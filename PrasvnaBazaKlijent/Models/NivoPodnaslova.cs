﻿using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class NivoPodnaslova
    {
        public NivoPodnaslova()
        {
            Podnaslov = new HashSet<Podnaslov>();
            PodnaslovPP = new HashSet<PodnaslovPP>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Podnaslov> Podnaslov { get; set; }
        public ICollection<PodnaslovPP> PodnaslovPP { get; set; }
    }
}
