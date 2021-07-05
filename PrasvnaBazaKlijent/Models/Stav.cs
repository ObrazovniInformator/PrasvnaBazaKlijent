using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class Stav
    {
        public Stav()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
            Tacka = new HashSet<Tacka>();
            PropisCasopis = new HashSet<PropisCasopis>();
            PropisInAkta = new HashSet<PropisInAkta>();
            PropisVest = new HashSet<PropisVest>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public int? IdClan { get; set; }

        public Clan IdClanNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        public ICollection<Tacka> Tacka { get; set; }
        public ICollection<PropisCasopis> PropisCasopis { get; set; }
        public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<PropisVest> PropisVest { get; set; }
    }
}
