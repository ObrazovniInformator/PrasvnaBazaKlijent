namespace PrasvnaBazaKlijent.Models
{
    public partial class SudskaPraksa
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Podnaslov { get; set; }
        public string Broj { get; set; }
        //public string Datum { get; set; }
        public string Napomena { get; set; }
        public string Tekst { get; set; }
        public string Datum { get; set; }
        public int? IdPropis { get; set; }
        public int? IdClan { get; set; }
        public int? IdStav { get; set; }
        public int? IdTacka { get; set; }
        public int? IdRubrikaSp { get; set; }
        public int? IdPodrubrikaSp { get; set; }
        public int? IdPodpodrubrikaSp { get; set; }
        public int? IdDonosilacSp { get; set; }

        public Clan IdClanNavigation { get; set; }
        public DonosilacSp IdDonosilacSpNavigation { get; set; }
        public PodpodrubrikaSp IdPodpodrubrikaSpNavigation { get; set; }
        public PodrubrikaSp IdPodrubrikaSpNavigation { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public RubrikaSp IdRubrikaSpNavigation { get; set; }
        public Stav IdStavNavigation { get; set; }
        public Tacka IdTackaNavigation { get; set; }
    }
}
