using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NickBuhro.Translit;
using PrasvnaBazaKlijent.Models;
using Cyrillic.Convert;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
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

        //public IActionResult GetItems(string v)// v is the entered text
        //{
        //    v = (v ?? "").ToLower().Trim();

        //    var items = _context.Propis.Where(o => o.Naslov.ToLower().Contains(v));

        //    return Json(items.Take(10).Select(o => o.Naslov));
        //}
        public string LatinCirToCir(string trazenaRec)
        {
            string tr = "";
            if (trazenaRec.Contains("ž"))
            {
                tr = trazenaRec.Replace("ž", "ж");
                // tr = trazenaRec.Replace("Ž", "Ж");
            }

            if (trazenaRec.Contains("ć"))
            {
                tr = trazenaRec.Replace("ć", "ћ");
                //   tr = trazenaRec.Replace("Ć", "Ћ");
            }

            if (trazenaRec.Contains("č"))
            {
                tr = trazenaRec.Replace("č", "ч");
                //  tr = trazenaRec.Replace("Č", "Ч");

            }

            if (trazenaRec.Contains("đ"))
            {
                tr = trazenaRec.Replace("đ", "ђ");
                //   tr = trazenaRec.Replace("Đ", "Ђ");
            }

            if (trazenaRec.Contains("š"))
            {
                tr = trazenaRec.Replace("š", "ш");
                // tr = trazenaRec.Replace("Š", "Ш");
            }

            return tr;
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
            string trazeniPropis = search;/*collection["Search"];*/


            if (trazeniPropis != null)
            {
                HttpContext.Session.SetString("trazeni", trazeniPropis);
            }
            else
            {
                trazeniPropis = "Zakon";
            }
            string trazeniPojam = trazeniPropis;
            if (trazeniPropis.Contains('š') || trazeniPropis.Contains('ž') || trazeniPropis.Contains('ć') || trazeniPropis.Contains('č'))
            {

                trazeniPojam = LatinCirToCir(trazeniPropis);
            }

            var cirilica = Transliteration.LatinToCyrillic(trazeniPojam, Language.Russian);

            if (cirilica.Contains("дз") || cirilica.Contains('й') || cirilica.Contains("дж"))
            {
                cirilica = cirilica.Replace("дз", "џ");
                cirilica = cirilica.Replace("дж", "џ");
                cirilica = cirilica.Replace('й', 'ј');


            }

            if(cirilica.Contains("лј") || cirilica.Contains("нј"))
            {
                cirilica = cirilica.Replace("лј", "љ");
                cirilica = cirilica.Replace("нј", "њ");

            }

            if (cirilica.Contains("аци") || cirilica.Contains("близим"))
            {
                cirilica = cirilica.Replace("аци", "ачи");
                cirilica = cirilica.Replace("близим", "ближим");
            }

            if (cirilica.Contains("скол") || cirilica.Contains("пс"))
            {
                cirilica = cirilica.Replace("скол", "школ");
                cirilica = cirilica.Replace("пс", "пш");

            }

            string[] reciZaTrazenje = cirilica.Split(' ');

            var propisi = from m in _context.Propis
                          select m;
            var ostaliPropisi = from m in _context.Propis
                                select m;
            var prosvetniPropisi = from m in _context.ProsvetnIPropis
                                   select m;
            var ostaliProsvetniPropisi = (from m in _context.ProsvetnIPropis
                                          select new ProsvetniPropis { Id = m.Id, Naslov = m.Naslov, GlasiloIDatumObjavljivanja = m.GlasiloIDatumObjavljivanja, VrstaPropisa = m.VrstaPropisa, DatumPrestankaVerzije = m.DatumPrestankaVerzije, DatumPrestankaVazenjaPropisa = m.DatumPrestankaVazenjaPropisa });
            if (!String.IsNullOrEmpty(trazeniPropis))
            {
                foreach (string r in reciZaTrazenje)
                {

                    propisi = propisi.Where(s => (s.Naslov.Contains(r)) && s.VrstaPropisa.Equals("Закон"));
                    ostaliPropisi = ostaliPropisi.Where(s => (s.Naslov.Contains(r)) && s.VrstaPropisa != "Закон");

                    prosvetniPropisi = prosvetniPropisi.Where(s => s.Naslov.Contains(r) && s.VrstaPropisa.Equals("Закон"));
                    ostaliProsvetniPropisi = ostaliProsvetniPropisi.Where(s => s.Naslov.Contains(r) && s.VrstaPropisa != ("Закон"));
                    //  Dictionary<int, string> ostaliProsvetniPropisi = _context.ProsvetnIPropis
                    // .Where(x => x.VrstaPropisa != "Закон")
                    //.Select(x => new KeyValuePair<int, string>(x.Id, x.Naslov))
                    //.ToDictionary(x => x.Key, x => x.Value);
                }
            }

            ViewBag.OstaliPropisi = ostaliPropisi;
            ViewBag.Reci = reciZaTrazenje;
            ViewBag.ProsvetniPropisi = prosvetniPropisi;
            ViewBag.OstaliProsvetniPropisi = ostaliProsvetniPropisi;
            return View(propisi);

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
            var cirilica = Transliteration.LatinToCyrillic(pojamZaPretragu, Language.Russian);
            string cirilicaKon = cirilica;
            if (cirilica.Contains("дз"))
            {
                cirilicaKon = cirilica.Replace("дз", "џ");
            }


            //PRETRAGA PO ODABRANIM POJMOVMA
            if (propisiCB == "on")
            {
                var propis = from p in _context.Propis
                             select p;
                propis = propis.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIdatumObjavljivanja.Contains(cirilica));
                if (nivoVazenjaSel != "nista")
                {
                    propis = propis.Where(s => s.NivoVazenja.Equals(nivoVazenjaSel));
                }

                if (vrstaPropisa != "nista")
                {
                    propis = propis.Where(s => s.VrstaPropisa.Equals(vrstaPropisa));
                }

                if (vaznost.Equals("nista") == false)
                {
                    if (vaznost.Equals("vazeci"))
                    {
                        propis = propis.Where(s => !(s.DatumPrestankaVazenjaPropisa.HasValue) && !(s.DatumPrestankaVerzije.HasValue));
                    }
                    else
                    {
                        propis = propis.Where(s => (s.DatumPrestankaVazenjaPropisa.HasValue) && (s.DatumPrestankaVazenjaPropisa.HasValue));
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
                                       select pp;
                prosvetniPropisi = prosvetniPropisi.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIDatumObjavljivanja.Contains(cirilicaKon));
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
            var cirilica = Transliteration.LatinToCyrillic(pojamZaPretragu, Language.Russian);
            string cirilicaKon = cirilica;
            if (cirilica.Contains("дз"))
            {
                cirilicaKon = cirilica.Replace("дз", "џ");
            }


            //PRETRAGA PO ODABRANIM POJMOVMA
            if (propisiCB == "on")
            {
                var propis = from p in _context.Propis
                             select p;
                propis = propis.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIdatumObjavljivanja.Contains(cirilica));
                if (nivoVazenjaSel != "nista")
                {
                    propis = propis.Where(s => s.NivoVazenja.Equals(nivoVazenjaSel));
                }

                if (vrstaPropisa != "nista")
                {
                    propis = propis.Where(s => s.VrstaPropisa.Equals(vrstaPropisa));
                }

                if (vaznost != "nista")
                {
                    if (vaznost == "vazeci")
                    {
                        propis = propis.Where(s => s.DatumPrestankaVazenjaPropisa.Value == null && s.DatumPrestankaVerzije.Value == null);
                    }

                    if (vaznost == "nevazeci")
                    {
                        propis = propis.Where(s => s.DatumPrestankaVazenjaPropisa.Value != null && s.DatumPrestankaVerzije.Value != null);
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
                                       select pp;
                prosvetniPropisi = prosvetniPropisi.Where(s => s.Naslov.Contains(cirilicaKon) || s.GlasiloIDatumObjavljivanja.Contains(cirilicaKon));
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
