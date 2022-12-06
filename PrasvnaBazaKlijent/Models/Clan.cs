using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class Clan
    {
        public Clan()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            Stav = new HashSet<Stav>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
            PropisCasopis = new HashSet<PropisCasopis>();
            PropisInAkta = new HashSet<PropisInAkta>();
            PropisVest = new HashSet<PropisVest>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodnaslov { get; set; }
        public int? IdPropis { get; set; }

        public Podnaslov IdPodnaslovNavigation { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<Stav> Stav { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        public ICollection<PropisCasopis> PropisCasopis { get; set; }
        public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<PropisVest> PropisVest { get; set; }
    }
}
