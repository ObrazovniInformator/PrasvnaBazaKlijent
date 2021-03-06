using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrasvnaBazaKlijent.Models
{
    public class StavPP
    {
        public StavPP()
        {
            TackaPP = new HashSet<TackaPP>();
            AlinejaPP = new HashSet<AlinejaPP>();
            //SudskaPraksa = new HashSet<SudskaPraksa>();
            //SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            //PropisCasopis = new HashSet<PropisCasopis>();
            //PropisInAkta = new HashSet<PropisInAkta>();
            ProsvetniPropisInAkta = new HashSet<ProsvetniPropisInAkta>();
            ProsvetniPropisSluzbenoMisljenje = new HashSet<ProsvetniPropisSluzbenoMisljenje>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public int IdClan { get; set; }

        public ClanPP IdClanNavigation { get; set; }
        public ICollection<TackaPP> TackaPP { get; set; }
        public ICollection<AlinejaPP> AlinejaPP { get; set; }
        //public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        //public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        //public ICollection<PropisCasopis> PropisCasopis { get; set; }
        //public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<ProsvetniPropisInAkta> ProsvetniPropisInAkta { get; set; }
        public ICollection<ProsvetniPropisSluzbenoMisljenje> ProsvetniPropisSluzbenoMisljenje { get; set; }
    }
}
