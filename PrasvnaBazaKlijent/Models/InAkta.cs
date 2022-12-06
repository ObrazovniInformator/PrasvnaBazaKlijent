﻿using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class InAkta
    {
        public InAkta()
        {
            PropisInAkta = new HashSet<PropisInAkta>();
            ProsvetniPropisInAkta = new HashSet<ProsvetniPropisInAkta>();
        }
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public string Autor { get; set; }
        public string DatumObjavljivanja { get; set; }
        public string Napomena { get; set; }
        public int? IdPropis { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public int? IdClan { get; set; }
        public Clan IdClanNavigation { get; set; }
        public int? IdStav { get; set; }
        public Stav IdStavNavigation { get; set; }
        public int? IdTacka { get; set; }
        public Tacka IdTackaNavigation { get; set; }
        public int? IdPodvrsta { get; set; }
        public InAktaPodvrsta IdPodvrstaNavigation { get; set; }
        public int? IdRubrika { get; set; }
        public RubrikaInAkta IdRubrikaInAktaNavigation { get; set; }
        public int? IdPodrubrika { get; set; }
        public PodrubrikaInAkta IdPodrubrikaInAktaNavigation { get; set; }
        public int? IdPodpodrubrika { get; set; }
        public PodpodrubrikaInAkta IdPodpodrubrikaInAktaNavigation { get; set; }

        public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<ProsvetniPropisInAkta> ProsvetniPropisInAkta { get; set; }

        public static void DodajInAkta(InAkta inAkta)
        {
            obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
            _context.InAkta.Add(inAkta);
            _context.SaveChanges();
        }
    }
}

