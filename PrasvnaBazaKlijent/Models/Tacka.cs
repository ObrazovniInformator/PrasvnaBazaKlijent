using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class Tacka
    {
        public Tacka()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
            PropisCasopis = new HashSet<PropisCasopis>();
            PropisInAkta = new HashSet<PropisInAkta>();
            PropisVest = new HashSet<PropisVest>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdStav { get; set; }
        public string Tekst { get; set; }

        public Stav IdStavNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        public ICollection<PropisCasopis> PropisCasopis { get; set; }
        public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<PropisVest> PropisVest { get; set; }
    }
}
