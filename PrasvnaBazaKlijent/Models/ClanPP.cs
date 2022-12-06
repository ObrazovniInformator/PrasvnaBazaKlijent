using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class ClanPP
    {
        public ClanPP()
        {
            StavPP = new HashSet<StavPP>();
            //SudskaPraksa = new HashSet<SudskaPraksa>();
            //SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            //PropisCasopis = new HashSet<PropisCasopis>();
            //PropisInAkta = new HashSet<PropisInAkta>();
            ProsvetniPropisInAkta = new HashSet<ProsvetniPropisInAkta>();
            ProsvetniPropisSluzbenoMisljenje = new HashSet<ProsvetniPropisSluzbenoMisljenje>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodnaslov { get; set; }
        public int IdPropis { get; set; }

        public ProsvetniPropis IdPropisNavigation { get; set; }
        public PodnaslovPP? IdPodnaslovNavigation { get; set; }
        public ICollection<StavPP> StavPP { get; set; }
        //public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        //public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        //public ICollection<PropisCasopis> PropisCasopis { get; set; }
        //public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<ProsvetniPropisInAkta> ProsvetniPropisInAkta { get; set; }
        public ICollection<ProsvetniPropisSluzbenoMisljenje> ProsvetniPropisSluzbenoMisljenje { get; set; }
    }
}
