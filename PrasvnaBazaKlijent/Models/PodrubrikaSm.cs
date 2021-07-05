using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class PodrubrikaSm
    {
        public PodrubrikaSm()
        {
            PodpodrubrikaSm = new HashSet<PodpodrubrikaSm>();
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdRubrika { get; set; }

        public RubrikaSm IdRubrikaNavigation { get; set; }
        public ICollection<PodpodrubrikaSm> PodpodrubrikaSm { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
    }
}
