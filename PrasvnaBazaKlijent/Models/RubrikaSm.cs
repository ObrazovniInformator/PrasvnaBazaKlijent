using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class RubrikaSm
    {
        public RubrikaSm()
        {
            PodrubrikaSm = new HashSet<PodrubrikaSm>();
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<PodrubrikaSm> PodrubrikaSm { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
    }
}
