using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class SluzbenoMisljenje
    {
        public SluzbenoMisljenje()
        {
            ProsvetniPropisSluzbenoMisljenje = new HashSet<ProsvetniPropisSluzbenoMisljenje>();
        }
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Podnaslov { get; set; }
        public string Broj { get; set; }
        public string DatumDonosenja { get; set; }
        public string Napomena { get; set; }
        public string Tekst { get; set; }
        public int? IdPropis { get; set; }
        public int? IdClan { get; set; }
        public int? IdStav { get; set; }
        public int? IdTacka { get; set; }
        public int? IdRubrikaSm { get; set; }
        public int? IdPodrubrikaSm { get; set; }
        public int? IdPodpodrubrikaSm { get; set; }
        public int? IdDonosilacSm { get; set; }
        public int? RedniBroj { get; set; }

        public Clan IdClanNavigation { get; set; }
        public DonosilacSm IdDonosilacSmNavigation { get; set; }
        public PodpodrubrikaSm IdPodpodrubrikaSmNavigation { get; set; }
        public PodrubrikaSm IdPodrubrikaSmNavigation { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public RubrikaSm IdRubrikaSmNavigation { get; set; }
        public Stav IdStavNavigation { get; set; }
        public Tacka IdTackaNavigation { get; set; }
        public ICollection<ProsvetniPropisSluzbenoMisljenje> ProsvetniPropisSluzbenoMisljenje { get; set; }
    }
}
