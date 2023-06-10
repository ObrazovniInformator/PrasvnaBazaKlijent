using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using Rotativa.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class TekstPropisaPPController : Controller
    {
        public IActionResult Index(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            {
                using (var _context = new obrazovn_AdminPanelContext())
                {
                    var propis = _context.ProsvetnIPropis
                        .AsNoTracking()
                        .SingleOrDefault(pr => pr.Id == id);

                    var pdfFajlovi = _context.PdfFajlProsvetniPropis
                        .AsNoTracking()
                        .Where(pd => pd.IdProsvetniPropis == id)
                        .ToList();

                    var podnaslov = _context.PodnaslovPP
                        .AsNoTracking()
                        .Where(p => p.IdPropis == propis.Id)
                        .ToList();

                    var clan = _context.ClanPP
                        .AsNoTracking()
                        .Where(c => c.IdPropis == propis.Id)
                        .ToList();

                    var idClana = _context.ClanPP
                        .Where(c => c.IdPropis == id)
                        .Select(c => c.Id)
                        .ToList();

                    var stav = _context.StavPP
                        .AsNoTracking()
                        .Where(st => idClana.Contains(st.IdClan))
                        .ToList();

                    var idStav = _context.StavPP
                        .Where(st => idClana.Contains(st.IdClan))
                        .Select(st => st.Id)
                        .ToList();

                    var tacka = _context.TackaPP
                        .AsNoTracking()
                        .Where(tac => idStav.Contains(tac.IdStav))
                        .ToList();

                    var alineja = _context.AlinejaPP
                        .AsNoTracking()
                        .Where(a => idStav.Contains(a.IdStav))
                        .ToList();

                    var vezeProsvetniPropisInAkta = _context.ProsvetniPropisInAkta
                        .AsNoTracking()
                        .Where(v => v.IdProsvetniPropis == id)
                        .ToList();

                    var idVezeInAkta = _context.ProsvetniPropisInAkta
                        .Where(v => v.IdProsvetniPropis == id)
                        .Select(v => v.IdInAkta)
                        .ToList();

                    var idStavovaDis = _context.ProsvetniPropisInAkta
                        .Where(st => st.IdProsvetniPropis == id)
                        .Select(st => st.IdStavPP)
                        .Distinct()
                        .ToList();

                    var idTackeDis = _context.ProsvetniPropisInAkta
                        .Where(t => t.IdProsvetniPropis == id && t.IdTackaPP != 0)
                        .Select(t => t.IdTackaPP)
                        .Distinct()
                        .ToList();

                    var inAKta = _context.InAkta
                        .AsNoTracking()
                        .Where(inAk => idVezeInAkta.Contains(inAk.Id))
                        .ToList();

                    var vezaPPSM = _context.ProsvetniPropisSluzbenoMisljenje
                        .AsNoTracking()
                        .Where(veza => veza.IdProsvetniPropis == id)
                        .ToList();

                    var idStavovaSMDis = _context.ProsvetniPropisSluzbenoMisljenje
                        .Where(st => st.IdProsvetniPropis == id)
                        .Select(st => st.IdStavPP)
                        .ToList();

                    var idSmVeza = _context.ProsvetniPropisSluzbenoMisljenje
                        .Where(veza => veza.IdProsvetniPropis == id)
                        .Select(veza => veza.IdSluzbenoMisljenje)
                        .ToList();

                    var sluzbenaMisljenja = _context.SluzbenoMisljenje
                        .AsNoTracking()
                        .Where(sm => idSmVeza.Contains(sm.Id))
                        .ToList();

                    ViewBag.Propis = propis;
                    ViewBag.PdfFajlovi = pdfFajlovi;
                    ViewBag.Podnaslovi = podnaslov;
                    ViewBag.Clanovi = clan;
                    ViewBag.Stavovi = stav;
                    ViewBag.Tacke = tacka;
                    ViewBag.Alineje = alineja;
                    //IN AKTA
                    ViewBag.VezeInAkta = vezeProsvetniPropisInAkta;
                    ViewBag.IdStavovaDis = idStavovaDis;
                    ViewBag.InAkta = inAKta;
                    ViewBag.IdTackeDis = idTackeDis;
                    //Sluzbeno Misljenje
                    ViewBag.VezeSluzbenaMisljenja = vezaPPSM;
                    ViewBag.IdStavovaSmDis = idStavovaSMDis;
                    ViewBag.SluzbenoMisljenje = sluzbenaMisljenja;

                    return View();
                }
            }
        }

        [HttpGet]
        public IActionResult VezaProsvetniPropisInAkta(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            using (var _context = new obrazovn_AdminPanelContext())
            {
                ProsvetniPropis propis = _context.ProsvetnIPropis.Find(id);

                InAkta inAkta = _context.InAkta.Find(idSm);

                List<PodnaslovPP> podnaslov = _context.PodnaslovPP
                    .Where(p => p.IdPropis == propis.Id)
                    .ToList();

                List<ClanPP> clan = _context.ClanPP
                    .Where(c => c.IdPropis == propis.Id)
                    .ToList();

                List<int> idClan = _context.ClanPP
                    .Where(c => c.IdPropis == id)
                    .Select(c => c.Id)
                    .ToList();

                List<StavPP> stav = _context.StavPP
                    .Where(st => idClan.Contains(st.IdClan))
                    .ToList();

                List<int> idStav = _context.StavPP
                    .Where(st => idClan.Contains(st.IdClan))
                    .Select(st => st.Id)
                    .ToList();

                List<TackaPP> tacka = _context.TackaPP
                    .Where(tac => idStav.Contains(tac.IdStav))
                    .ToList();

                List<AlinejaPP> alineja = _context.AlinejaPP
                    .Where(a => idStav.Contains(a.IdStav))
                    .ToList();

                ViewBag.Propis = propis;
                ViewBag.InAkta = inAkta;
                ViewBag.Podnaslovi = podnaslov;
                ViewBag.Clanovi = clan;
                ViewBag.Stavovi = stav;
                ViewBag.Tacke = tacka;
                ViewBag.Alineje = alineja;

                return View();
            }
        }

        [HttpGet]
        public IActionResult VezeProsvetniPropisSluzbenoMisljenje(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            using (var _context = new obrazovn_AdminPanelContext())
            {
                ProsvetniPropis propis = _context.ProsvetnIPropis.FirstOrDefault(pr => pr.Id == id);
                SluzbenoMisljenje sm = _context.SluzbenoMisljenje.FirstOrDefault(s => s.Id == idSm);

                List<PodnaslovPP> podnaslov = (from p in _context.PodnaslovPP
                                               where p.IdPropis == propis.Id
                                               select p).ToList();

                List<ClanPP> clan = (from c in _context.ClanPP
                                     where c.IdPropis == propis.Id
                                     select c).ToList();

                List<int> idClan = (from c in _context.ClanPP
                                    where c.IdPropis == id
                                    select c.Id).ToList();

                List<StavPP> stav = (from st in _context.StavPP
                                     where idClan.Contains(st.IdClan)
                                     select st).ToList();

                List<int> idStav = (from st in _context.StavPP
                                    where idClan.Contains(st.IdClan)
                                    select st.Id).ToList();

                List<TackaPP> tacka = (from tac in _context.TackaPP
                                       where idStav.Contains(tac.IdStav)
                                       select tac).ToList();

                List<AlinejaPP> alineja = (from a in _context.AlinejaPP
                                           where idStav.Contains(a.IdStav)
                                           select a).ToList();

                ViewBag.Propis = propis;
                ViewBag.SluzbenoMisljenje = sm;
                ViewBag.Podnaslovi = podnaslov;
                ViewBag.Clanovi = clan;
                ViewBag.Stavovi = stav;
                ViewBag.Tacke = tacka;
                ViewBag.Alineje = alineja;

                return View();
            }
        }

        public IActionResult StampajPropis(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                ProsvetniPropis propis = _context.ProsvetnIPropis.Find(id);

                return new ViewAsPdf("StampajPropis", propis);
            }
        }

        public IActionResult CitajPdf(int id)
        {
            var _context = new obrazovn_AdminPanelContext();
            PdfFajlProsvetniPropis fajl = (from p in _context.PdfFajlProsvetniPropis
                                           where p.Id == id
                                           select p).SingleOrDefault();
            string putanja = fajl.PdfPath;
            return File(System.IO.File.ReadAllBytes(putanja), "application/pdf");
        }
    }
}