using System;

namespace PrasvnaBazaKlijent.Models
{
    public class ProsvetniPropisSluzbenoMisljenje
    {
        public int Id { get; set; }
        public int? IdSluzbenoMisljenje { get; set; }
        public SluzbenoMisljenje IdSluzbenoMisljenjeNavigation { get; set; }
        public int? IdProsvetniPropis { get; set; }
        public ProsvetniPropis IdProsvetniPropisNavigation { get; set; }
        public int? IdClanPP { get; set; }
        public ClanPP IdClanPPNavigation { get; set; }
        public int? IdStavPP { get; set; }
        public StavPP IdStavPPNavigation { get; set; }
        public int? IdTackaPP { get; set; }
        public TackaPP IdTackaPPNavigation { get; set; }
        public DateTime? DatumUnosa { get; set; }
    }
}
