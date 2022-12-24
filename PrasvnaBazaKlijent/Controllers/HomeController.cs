using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PrasvnaBazaKlijent.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Transactions;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {

                List<PropisVest> vezaPropis = _context.PropisVest.AsNoTracking().ToList();
                Vest[] vesti = _context.Vest.OrderBy(id => id.Id).AsNoTracking().ToArray();
                List<string> propisiN = (from p in _context.Propis
                                         select p.Naslov).AsNoTracking().ToList();
                ViewBag.VezePropis = vezaPropis;
                ViewBag.Vest = vesti;
                ViewBag.data = propisiN;

                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static string ToCir(string text)
        {
            var latin = text;

            latin = latin.Replace("nj", "њ");
            latin = latin.Replace("dž", "џ");
            latin = latin.Replace("lj", "љ");

            latin = latin.Replace("DŽ", "Џ");
            latin = latin.Replace("LJ", "Љ");
            latin = latin.Replace("NJ", "Њ");
            latin = latin.Replace("Dž", "Џ");
            latin = latin.Replace("Lj", "Љ");
            latin = latin.Replace("Nj", "Њ");

            latin = latin.Replace('a', 'а');
            latin = latin.Replace('b', 'б');
            latin = latin.Replace('v', 'в');
            latin = latin.Replace('g', 'г');
            latin = latin.Replace('d', 'д');
            latin = latin.Replace('đ', 'ђ');
            latin = latin.Replace('e', 'е');
            latin = latin.Replace('ž', 'ж');
            latin = latin.Replace('z', 'з');
            latin = latin.Replace('i', 'и');
            latin = latin.Replace('j', 'ј');
            latin = latin.Replace('k', 'к');
            latin = latin.Replace('l', 'л');
            latin = latin.Replace('m', 'м');
            latin = latin.Replace('n', 'н');
            latin = latin.Replace('o', 'о');
            latin = latin.Replace('p', 'п');
            latin = latin.Replace('r', 'р');
            latin = latin.Replace('s', 'с');
            latin = latin.Replace('t', 'т');
            latin = latin.Replace('ć', 'ћ');
            latin = latin.Replace('u', 'у');
            latin = latin.Replace('f', 'ф');
            latin = latin.Replace('h', 'х');
            latin = latin.Replace('c', 'ц');
            latin = latin.Replace('č', 'ч');
            latin = latin.Replace('š', 'ш');

            latin = latin.Replace('A', 'А');
            latin = latin.Replace('B', 'Б');
            latin = latin.Replace('V', 'В');
            latin = latin.Replace('G', 'Г');
            latin = latin.Replace('D', 'Д');
            latin = latin.Replace('Đ', 'Ђ');
            latin = latin.Replace('E', 'Е');
            latin = latin.Replace('Ž', 'Ж');
            latin = latin.Replace('Z', 'З');
            latin = latin.Replace('I', 'И');
            latin = latin.Replace('J', 'Ј');
            latin = latin.Replace('K', 'К');
            latin = latin.Replace('L', 'Л');
            latin = latin.Replace('M', 'М');
            latin = latin.Replace('N', 'Н');
            latin = latin.Replace('O', 'О');
            latin = latin.Replace('P', 'П');
            latin = latin.Replace('R', 'Р');
            latin = latin.Replace('S', 'С');
            latin = latin.Replace('T', 'Т');
            latin = latin.Replace('Ć', 'Ћ');
            latin = latin.Replace('U', 'У');
            latin = latin.Replace('F', 'Ф');
            latin = latin.Replace('H', 'Х');
            latin = latin.Replace('C', 'Ц');
            latin = latin.Replace('Č', 'Ч');
            latin = latin.Replace('Š', 'Ш');

            return latin;
        }

        private static string ToLatin(string text)
        {

            var cyrilic = text;
            cyrilic = cyrilic.Replace("њ", "nj");
            cyrilic = cyrilic.Replace("џ", "dž");
            cyrilic = cyrilic.Replace("љ", "lj");

            cyrilic = cyrilic.Replace("Џ", "DŽ");
            cyrilic = cyrilic.Replace("Љ", "LJ");
            cyrilic = cyrilic.Replace("Њ", "NJ");
            cyrilic = cyrilic.Replace("Џ", "Dž");
            cyrilic = cyrilic.Replace("Љ", "Lj");
            cyrilic = cyrilic.Replace("Њ", "Nj");

            cyrilic = cyrilic.Replace('а', 'a');
            cyrilic = cyrilic.Replace('б', 'b');
            cyrilic = cyrilic.Replace('в', 'v');
            cyrilic = cyrilic.Replace('г', 'g');
            cyrilic = cyrilic.Replace('д', 'd');
            cyrilic = cyrilic.Replace('ђ', 'đ');
            cyrilic = cyrilic.Replace('е', 'e');
            cyrilic = cyrilic.Replace('ж', 'ž');
            cyrilic = cyrilic.Replace('з', 'z');
            cyrilic = cyrilic.Replace('и', 'i');
            cyrilic = cyrilic.Replace('ј', 'j');
            cyrilic = cyrilic.Replace('к', 'k');
            cyrilic = cyrilic.Replace('л', 'l');
            cyrilic = cyrilic.Replace('м', 'm');
            cyrilic = cyrilic.Replace('н', 'n');
            cyrilic = cyrilic.Replace('о', 'o');
            cyrilic = cyrilic.Replace('п', 'p');
            cyrilic = cyrilic.Replace('р', 'r');
            cyrilic = cyrilic.Replace('с', 's');
            cyrilic = cyrilic.Replace('т', 't');
            cyrilic = cyrilic.Replace('ћ', 'ć');
            cyrilic = cyrilic.Replace('у', 'u');
            cyrilic = cyrilic.Replace('ф', 'f');
            cyrilic = cyrilic.Replace('х', 'h');
            cyrilic = cyrilic.Replace('ц', 'c');
            cyrilic = cyrilic.Replace('ч', 'č');
            cyrilic = cyrilic.Replace('ш', 'š');

            cyrilic = cyrilic.Replace('А', 'A');
            cyrilic = cyrilic.Replace('Б', 'B');
            cyrilic = cyrilic.Replace('В', 'V');
            cyrilic = cyrilic.Replace('Г', 'G');
            cyrilic = cyrilic.Replace('Д', 'D');
            cyrilic = cyrilic.Replace('Ђ', 'Đ');
            cyrilic = cyrilic.Replace('Е', 'E');
            cyrilic = cyrilic.Replace('Ж', 'Ž');
            cyrilic = cyrilic.Replace('З', 'Z');
            cyrilic = cyrilic.Replace('И', 'I');
            cyrilic = cyrilic.Replace('Ј', 'J');
            cyrilic = cyrilic.Replace('К', 'K');
            cyrilic = cyrilic.Replace('Л', 'L');
            cyrilic = cyrilic.Replace('М', 'M');
            cyrilic = cyrilic.Replace('Н', 'N');
            cyrilic = cyrilic.Replace('О', 'O');
            cyrilic = cyrilic.Replace('П', 'P');
            cyrilic = cyrilic.Replace('Р', 'R');
            cyrilic = cyrilic.Replace('С', 'S');
            cyrilic = cyrilic.Replace('Т', 'T');
            cyrilic = cyrilic.Replace('Ћ', 'Ć');
            cyrilic = cyrilic.Replace('У', 'U');
            cyrilic = cyrilic.Replace('Ф', 'F');
            cyrilic = cyrilic.Replace('Х', 'H');
            cyrilic = cyrilic.Replace('Ц', 'C');
            cyrilic = cyrilic.Replace('Ч', 'Č');
            cyrilic = cyrilic.Replace('Ш', 'Š');

            return cyrilic;

        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            string trazeniPropis = search;

            if (trazeniPropis != null)
            {
                HttpContext.Session.SetString("trazeni", trazeniPropis);
            }
            else
            {
                trazeniPropis = "Zakon";
            }

            string trazeniPojam = trazeniPropis;

            trazeniPojam = ToCir(trazeniPropis);

            string[] reciZaTrazenje = trazeniPojam.Split(' ');

            var propisi = from m in _context.Propis
                          select m;
            var ostaliPropisi = from m in _context.Propis
                                select m;
            var prosvetniPropisi = from m in _context.ProsvetnIPropis
                                   select m;
            var ostaliProsvetniPropisi = (from m in _context.ProsvetnIPropis
                                          select m /*new ProsvetniPropis { Id = m.Id, Naslov = m.Naslov, GlasiloIDatumObjavljivanja = m.GlasiloIDatumObjavljivanja, VrstaPropisa = m.VrstaPropisa, DatumPrestankaVerzije = m.DatumPrestankaVerzije, DatumPrestankaVazenjaPropisa = m.DatumPrestankaVazenjaPropisa })*/);
            var casopisi = from m in _context.CasopisNaslov
                           select m;
            var inAkta = from m in _context.InAkta
                         select m;
            var sluzbenaMisljenja = from m in _context.SluzbenoMisljenje
                                    select m;
            var sudskePrakse = from m in _context.SudskaPraksa
                               select m;
            var primeriKnjizenja = from m in _context.PrimeriKnjizenja
                                   select m;

            if (!String.IsNullOrEmpty(trazeniPropis))
            {
                foreach (string r in reciZaTrazenje)
                {
                    propisi = propisi.Where(s => (s.Naslov.Contains(r)) && s.VrstaPropisa.Equals("Закон")).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                    ostaliPropisi = ostaliPropisi.Where(s => (s.Naslov.Contains(r)) && s.VrstaPropisa != "Закон").OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                    prosvetniPropisi = prosvetniPropisi.Where(s => s.Naslov.Contains(r) && s.VrstaPropisa.Equals("Закон")).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                    ostaliProsvetniPropisi = ostaliProsvetniPropisi.Where(s => s.Naslov.Contains(r) && s.VrstaPropisa != ("Закон")).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                    casopisi = casopisi.Where(s => s.Naslov.Contains(r));
                    inAkta = inAkta.Where(s => s.Naslov.Contains(r));
                    sluzbenaMisljenja = sluzbenaMisljenja.Where(s => s.Naslov.Contains(r));
                    sudskePrakse = sudskePrakse.Where(s => s.Naslov.Contains(r));
                    primeriKnjizenja = primeriKnjizenja.Where(s => s.Naslov.Contains(r));
                }
            }

            ViewBag.OstaliPropisi = ostaliPropisi;
            ViewBag.Reci = reciZaTrazenje;
            ViewBag.ProsvetniPropisi = prosvetniPropisi;
            ViewBag.OstaliProsvetniPropisi = ostaliProsvetniPropisi;
            ViewBag.Casopisi = casopisi;
            ViewBag.InAkta = inAkta;
            ViewBag.SluzbenaMisljenja = sluzbenaMisljenja;
            ViewBag.SudskePrakse = sudskePrakse;
            ViewBag.PrimeriKnjizenja = primeriKnjizenja;

            return View(Tuple.Create(propisi, prosvetniPropisi, casopisi, inAkta, sluzbenaMisljenja, sudskePrakse, primeriKnjizenja));
        }

        public IActionResult NaprednaPretraga(IFormCollection formCollection)
        {
            obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
            //CHEKBOXOVI i polja sa forme
            var pojamZaPretragu = formCollection["pojamZaPretragu"];
            var propisiCB = formCollection["Propisi"];
            var inAktaCB = formCollection["InAkta"];
            var prosvetniPropisiCB = formCollection["ProsvetniPropisi"];
            var sudskaPraksaCB = formCollection["SudskaPraksa"];
            var sluzbenoMisljenjeCB = formCollection["SluzbenoMisljenje"];
            var pravniSavetnikCB = formCollection["PravniSavetnik"];
            var podsetnikZaDirektoreCB = formCollection["PodsetnikZaDirektore"];
            var budzetskoRacunovodstvoCB = formCollection["BudzetskoRacunovodstvo"];
            var nivoVazenjaSel = formCollection["NivoVazenja"];
            var vrstaPropisa = formCollection["VrstaPropisa"];
            var vaznost = formCollection["Vaznost"];

            HttpContext.Session.SetString("pojamZaPretragu", pojamZaPretragu);
            if (String.IsNullOrEmpty(propisiCB) == false)
            {
                HttpContext.Session.SetString("propisiCb", propisiCB);
            }
            if (String.IsNullOrEmpty(inAktaCB) == false)
            {
                HttpContext.Session.SetString("inAktaCb", inAktaCB);
            }

            if (String.IsNullOrEmpty(prosvetniPropisiCB) == false)
            {
                HttpContext.Session.SetString("prosvetniPropisiCB", prosvetniPropisiCB);
            }
            if (String.IsNullOrEmpty(sudskaPraksaCB) == false)
            {
                HttpContext.Session.SetString("sudskaPraksaCB", sudskaPraksaCB);
            }
            if (String.IsNullOrEmpty(sluzbenoMisljenjeCB) == false)
            {
                HttpContext.Session.SetString("sluzbenoMisljenjeCB", sluzbenoMisljenjeCB);
            }
            if (String.IsNullOrEmpty(pravniSavetnikCB) == false)
            {
                HttpContext.Session.SetString("pravniSavetnikCB", pravniSavetnikCB);
            }
            if (String.IsNullOrEmpty(podsetnikZaDirektoreCB) == false)
            {
                HttpContext.Session.SetString("podsetnikZaDirektoreCB", podsetnikZaDirektoreCB);
            }
            if (String.IsNullOrEmpty(budzetskoRacunovodstvoCB) == false)
            {
                HttpContext.Session.SetString("budzetskoRacunovodstvoCB", budzetskoRacunovodstvoCB);
            }
            if (String.IsNullOrEmpty(nivoVazenjaSel) == false)
            {
                HttpContext.Session.SetString("nivoVazenjaSel", nivoVazenjaSel);
            }
            if (String.IsNullOrEmpty(vrstaPropisa) == false)
            {
                HttpContext.Session.SetString("vrstaPropisa", vrstaPropisa);
            }
            if (String.IsNullOrEmpty(vaznost) == false)
            {
                HttpContext.Session.SetString("vaznost", vaznost);
            }

            //PREVOD NA CIRILICU JER UNOSE IMENA PROPISA I LATINICOM
            var cirilica = ToCir(pojamZaPretragu);
            string cirilicaKon = cirilica;

            //PRETRAGA PO ODABRANIM POJMOVMA
            if (propisiCB == "on")
            {
                var propis = from p in _context.Propis
                             //orderby p.RedniBroj ascending
                             select p;
                propis = (IOrderedQueryable<Propis>)propis.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIdatumObjavljivanja.Contains(cirilica)).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                if (nivoVazenjaSel != "nista")
                {
                    propis = (IOrderedQueryable<Propis>)propis.Where(s => s.NivoVazenja.Equals(nivoVazenjaSel)).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                }

                if (vrstaPropisa != "nista")
                {
                    propis = (IOrderedQueryable<Propis>)propis.Where(s => s.VrstaPropisa.Equals(vrstaPropisa)).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                }

                if (vaznost.Equals("nista") == false)
                {
                    if (vaznost.Equals("vazeci"))
                    {
                        propis = (IOrderedQueryable<Propis>)propis.Where(s => !(s.DatumPrestankaVazenjaPropisa.HasValue) && !(s.DatumPrestankaVerzije.HasValue)).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                    }
                    else
                    {
                        propis = (IOrderedQueryable<Propis>)propis.Where(s => (s.DatumPrestankaVazenjaPropisa.HasValue) && (s.DatumPrestankaVazenjaPropisa.HasValue)).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                    }
                }
                ViewBag.Propis = propis;
            }

            if (inAktaCB == "on")
            {
                var inAkta = from ina in _context.InAkta
                             select ina;
                inAkta = inAkta.Where(s => s.Naslov.Contains(cirilicaKon) || s.DatumObjavljivanja.Contains(cirilicaKon));
                ViewBag.InAkta = inAkta;
            }

            if (prosvetniPropisiCB == "on")
            {
                var prosvetniPropisi = from pp in _context.ProsvetnIPropis
                                       //orderby pp.RedniBroj ascending
                                       select pp;
                prosvetniPropisi = (IOrderedQueryable<ProsvetniPropis>)prosvetniPropisi.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIDatumObjavljivanja.Contains(cirilicaKon)).OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                ViewBag.ProsvetniPropisi = prosvetniPropisi;
            }

            if (sudskaPraksaCB == "on")
            {
                var sudskaPraksa = from sp in _context.SudskaPraksa
                                   select sp;
                sudskaPraksa = sudskaPraksa.Where(s => s.Naslov.Contains(cirilicaKon) || s.Podnaslov.Contains(cirilicaKon));
                ViewBag.SudskaPraksa = sudskaPraksa;
            }

            if (sluzbenoMisljenjeCB == "on")
            {
                var sluzbenoMisljenje = from sm in _context.SluzbenoMisljenje
                                        select sm;
                sluzbenoMisljenje = sluzbenoMisljenje.Where(s => s.Naslov.Contains(cirilicaKon) || s.Podnaslov.Contains(cirilicaKon));
                ViewBag.SluzbenoMisljenje = sluzbenoMisljenje;
            }

            if (pravniSavetnikCB == "on")
            {
                var pravniSavetnk = from ps in _context.CasopisNaslov
                                    where ps.IdOblast == 2
                                    select ps;
                pravniSavetnk = pravniSavetnk.Where(s => s.Naslov.Contains(cirilicaKon));
                ViewBag.PravniSavetnik = pravniSavetnk;
            }

            if (podsetnikZaDirektoreCB == "on")
            {
                var podsetnkZaDirektore = from pzd in _context.CasopisNaslov
                                          where pzd.IdOblast == 3
                                          select pzd;
                podsetnkZaDirektore = podsetnkZaDirektore.Where(s => s.Naslov.Contains(cirilicaKon));

                ViewBag.PodsetnikZaDirektore = podsetnkZaDirektore;
            }

            if (budzetskoRacunovodstvoCB == "on")
            {
                var budzetskoRacunovodstvo = from br in _context.CasopisNaslov
                                             where br.IdOblast == 1
                                             select br;
                budzetskoRacunovodstvo = budzetskoRacunovodstvo.Where(s => s.Naslov.Contains(cirilicaKon));
                ViewBag.BudzetskoRacunovodstvo = budzetskoRacunovodstvo;
            }

            return View();
        }

        [HttpGet]
        public IActionResult NaprednaPretraga()
        {
            obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
            //CHEKBOXOVI i polja sa forme
            var pojamZaPretragu = HttpContext.Session.GetString("pojamZaPretragu");
            var propisiCB = HttpContext.Session.GetString("propisiCb");
            var inAktaCB = HttpContext.Session.GetString("inAktaCb");
            var prosvetniPropisiCB = HttpContext.Session.GetString("prosvetniPropisiCB");
            var sudskaPraksaCB = HttpContext.Session.GetString("sudskaPraksaCB");
            var sluzbenoMisljenjeCB = HttpContext.Session.GetString("sluzbenoMisljenjeCB");
            var pravniSavetnikCB = HttpContext.Session.GetString("pravniSavetnikCB");
            var podsetnikZaDirektoreCB = HttpContext.Session.GetString("podsetnikZaDirektoreCB");
            var budzetskoRacunovodstvoCB = HttpContext.Session.GetString("budzetskoRacunovodstvoCB");
            var nivoVazenjaSel = HttpContext.Session.GetString("nivoVazenjaSel");
            var vrstaPropisa = HttpContext.Session.GetString("vrstaPropisa");
            var vaznost = HttpContext.Session.GetString("vaznost");

            //PREVOD NA CIRILICU JER UNOSE IMENA PROPISA I LATINICOM
            var cirilica = ToCir(pojamZaPretragu);
            string cirilicaKon = cirilica;

            //PRETRAGA PO ODABRANIM POJMOVMA
            if (propisiCB == "on")
            {
                var propis = from p in _context.Propis
                             orderby p.RedniBroj ascending
                             select p;
                propis = (IOrderedQueryable<Propis>)propis.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIdatumObjavljivanja.Contains(cirilica));
                if (nivoVazenjaSel != "nista")
                {
                    propis = (IOrderedQueryable<Propis>)propis.Where(s => s.NivoVazenja.Equals(nivoVazenjaSel));
                }

                if (vrstaPropisa != "nista")
                {
                    propis = (IOrderedQueryable<Propis>)propis.Where(s => s.VrstaPropisa.Equals(vrstaPropisa));
                }

                if (vaznost != "nista")
                {
                    if (vaznost == "vazeci")
                    {
                        propis = (IOrderedQueryable<Propis>)propis.Where(s => s.DatumPrestankaVazenjaPropisa.Value == null && s.DatumPrestankaVerzije.Value == null);
                    }

                    if (vaznost == "nevazeci")
                    {
                        propis = (IOrderedQueryable<Propis>)propis.Where(s => s.DatumPrestankaVazenjaPropisa.Value != null && s.DatumPrestankaVerzije.Value != null);
                    }
                }

                ViewBag.Propis = propis;
            }

            if (inAktaCB == "on")
            {
                var inAkta = from ina in _context.InAkta
                             select ina;
                inAkta = inAkta.Where(s => s.Naslov.Contains(cirilicaKon) || s.DatumObjavljivanja.Contains(cirilicaKon));
                ViewBag.InAkta = inAkta;
            }

            if (prosvetniPropisiCB == "on")
            {
                var prosvetniPropisi = from pp in _context.ProsvetnIPropis
                                       orderby pp.RedniBroj ascending
                                       select pp;
                prosvetniPropisi = (IOrderedQueryable<ProsvetniPropis>)prosvetniPropisi.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIDatumObjavljivanja.Contains(cirilicaKon));
                ViewBag.ProsvetniPropisi = prosvetniPropisi;
            }

            if (sudskaPraksaCB == "on")
            {
                var sudskaPraksa = from sp in _context.SudskaPraksa
                                   select sp;
                sudskaPraksa = sudskaPraksa.Where(s => s.Naslov.Contains(cirilicaKon) || s.Podnaslov.Contains(cirilicaKon));
                ViewBag.SudskaPraksa = sudskaPraksa;
            }

            if (sluzbenoMisljenjeCB == "on")
            {
                var sluzbenoMisljenje = from sm in _context.SluzbenoMisljenje
                                        select sm;
                sluzbenoMisljenje = sluzbenoMisljenje.Where(s => s.Naslov.Contains(cirilicaKon) || s.Podnaslov.Contains(cirilicaKon));
                ViewBag.SluzbenoMisljenje = sluzbenoMisljenje;
            }

            if (pravniSavetnikCB == "on")
            {
                var pravniSavetnk = from ps in _context.CasopisNaslov
                                    where ps.IdOblast == 2
                                    select ps;
                pravniSavetnk = pravniSavetnk.Where(s => s.Naslov.Contains(cirilicaKon));
                ViewBag.PravniSavetnik = pravniSavetnk;
            }

            if (podsetnikZaDirektoreCB == "on")
            {
                var podsetnkZaDirektore = from pzd in _context.CasopisNaslov
                                          where pzd.IdOblast == 3
                                          select pzd;
                podsetnkZaDirektore = podsetnkZaDirektore.Where(s => s.Naslov.Contains(cirilicaKon));

                ViewBag.PodsetnikZaDirektore = podsetnkZaDirektore;
            }

            if (budzetskoRacunovodstvoCB == "on")
            {
                var budzetskoRacunovodstvo = from br in _context.CasopisNaslov
                                             where br.IdOblast == 1
                                             select br;
                budzetskoRacunovodstvo = budzetskoRacunovodstvo.Where(s => s.Naslov.Contains(cirilicaKon));
                ViewBag.BudzetskoRacunovodstvo = budzetskoRacunovodstvo;
            }

            return View();
        }

        [HttpGet]
        public IActionResult PrikazVestiSve(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                VestiKategorija kategorija = _context.VestiKategorija.Find(id);
                List<Vest> vesti = (from v in _context.Vest
                                    orderby v.Id descending
                                    where v.IdKategorija == id
                                    select new Vest { Id = v.Id, Naslov = v.Naslov, DanUMesecu = v.DanUMesecu, DanUNedelji = v.DanUNedelji, Mesec = v.Mesec, Godina = v.Godina }).ToList();
                ViewBag.Vesti = vesti;
                return View();
            }
        }

        public IActionResult JednaVest(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                Vest vest = _context.Vest.Find(id);
                ViewBag.Vest = vest;
                return View();
            }
        }
    }
}
