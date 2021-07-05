using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrasvnaBazaKlijent.Models
{
    public class PropisVest
    {
        public int Id { get; set; }
        public int? IdPropis { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public int? IdVest { get; set; }
        public Vest IdVestNavigation { get; set; }
        public int? IdClan { get; set; }
        public Clan IdClanNavigation { get; set; }
        public int? IdStav { get; set; }
        public Stav IdStavNavigation { get; set; }
        public int? IdTacka { get; set; }
        public Tacka IdTackaNavigation { get; set; }
        public DateTime? DatumUnosa { get; set; }
    }
}
