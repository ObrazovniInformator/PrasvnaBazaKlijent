using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class ProsvetniPropis
    {
        public ProsvetniPropis()
        {
            ClanPP = new HashSet<ClanPP>();
            PodnaslovPP = new HashSet<PodnaslovPP>();
            //SudskaPraksa = new HashSet<SudskaPraksa>();
            //SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            //PropisCasopis = new HashSet<PropisCasopis>();
            //PropisInAkta = new HashSet<PropisInAkta>();
            ProsvetniPropisInAkta = new HashSet<ProsvetniPropisInAkta>();
            ProsvetniPropisSluzbenoMisljenje = new HashSet<ProsvetniPropisSluzbenoMisljenje>();

        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public int? IdRubrike { get; set; }
        public int? IdPodrubrike { get; set; }
        public string GlasiloIDatumObjavljivanja { get; set; }
        public string VrstaPropisa { get; set; }
        public string Donosilac { get; set; }
        public string NivoVazenja { get; set; }
        public DateTime? DatumStupanjaNaSnaguVerzijePropisa { get; set; }
        public DateTime? DatumPrestankaVerzije { get; set; }
        public DateTime? DatumObjavljivanjaVerzije { get; set; }
        public DateTime? DatumObjavljivanjaOsnovnogTeksta { get; set; }
        public DateTime? DatumStupanjaNaSnaguMeđunarodnogUgovora { get; set; }
        public DateTime? DatumStupanjaNaSnaguOsnovnogTekstaPropisa { get; set; }
        public DateTime? DatumPrestankaVazenjaPropisa { get; set; }
        public DateTime? DatumPocetkaPrimene { get; set; }
        public string PravniOsnovZaDonosenjaPropisa { get; set; }
        public string NormaOsnovaZaDonosenje { get; set; }
        public string PropisKojiJePrestaoDaVazi { get; set; }
        public string NormaOsnovaZaPrestanakVazenja { get; set; }
        //  public string NormaOsnovaZaPrestanakVazenjaPrethodnika { get; set; }
        public string DatumPrestankaVazenjaPravnogPrethodnika { get; set; }
        public string IstorijskaVerzijaPropisa { get; set; }
        public string Napomena { get; set; }
        public string ReferencaNaPropis { get; set; }
        public string NapomeneGlasnika { get; set; }
        public string TekstPropisa { get; set; }
        public string Preambula { get; set; }
        public int? RedniBroj { get; set; }

        public PodrubrikaPP IdPodrubrikaNavigation { get; set; }
        public RubrikaPP IdRubrikaNavigation { get; set; }
        public ICollection<ClanPP> ClanPP { get; set; }
        public ICollection<PodnaslovPP> PodnaslovPP { get; set; }
        //public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        //public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        //public ICollection<PropisCasopis> PropisCasopis { get; set; }
        //public ICollection<PropisInAkta> PropisInAkta { get; set; }
        public ICollection<ProsvetniPropisInAkta> ProsvetniPropisInAkta { get; set; }
        public ICollection<ProsvetniPropisSluzbenoMisljenje> ProsvetniPropisSluzbenoMisljenje { get; set; }
        public ICollection<PdfFajlProsvetniPropis> PdfFajlProsvetniPropis { get; set; }
    }
}
