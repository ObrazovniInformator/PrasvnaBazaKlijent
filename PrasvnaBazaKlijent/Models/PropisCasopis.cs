﻿using System;

namespace PrasvnaBazaKlijent.Models
{
    public class PropisCasopis
    {
        public int Id { get; set; }
        public int? IdCasopis { get; set; }
        public CasopisNaslov IdCasopisNaslovNavigation { get; set; }
        public int? IdPropis { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public int? IdClan { get; set; }
        public Clan IdClanNavigation { get; set; }
        public int? IdStav { get; set; }
        public Stav IdStavNavigation { get; set; }
        public int? IdTacka { get; set; }
        public Tacka IdTackaNavigation { get; set; }
        public DateTime? DatumUnosa { get; set; }


    }
}