﻿using System;

namespace PrasvnaBazaKlijent.Models
{
    public class PropisInAkta
    {
        public int Id { get; set; }
        public int? IdInAkta { get; set; }
        public InAkta IdInAktaNavigation { get; set; }
        public int? IdPropis { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public int? IdClan { get; set; }
        public Clan IdClanNavigation { get; set; }
        public int? IdStav { get; set; }
        public Stav IdStavNavigation { get; set; }
        public int? IdTacka { get; set; }
        public Tacka IdTackaNavigation { get; set; }
        public DateTime? DatumUnosa { get; set; }

        public static void DodajVezuPropisInAkta(PropisInAkta propisInAkta)
        {
            obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
            _context.PropisInAkta.Add(propisInAkta);
            _context.SaveChanges();
        }
    }
}
