using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class PodpodrubrikaSm
    {
        public PodpodrubrikaSm()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodrubrika { get; set; }

        public PodrubrikaSm IdPodrubrikaNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
    }
}
