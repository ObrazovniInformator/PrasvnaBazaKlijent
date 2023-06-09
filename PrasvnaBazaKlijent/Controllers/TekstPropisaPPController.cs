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
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                ProsvetniPropis propis = (from pr in _context.ProsvetnIPropis
                                          where pr.Id == id
                                          select pr).AsNoTracking().SingleOrDefault();
                List<PdfFajlProsvetniPropis> pdfFajlovi = (from pd in _context.PdfFajlProsvetniPropis
                                                           where pd.IdProsvetniPropis == id
                                                           select pd).ToList();
                List<PodnaslovPP> podnaslov = (from p in _context.PodnaslovPP
                                               where p.IdPropis == propis.Id
                                               select p).AsNoTracking().ToList();
                List<ClanPP> clan = (from c in _context.ClanPP
                                     where c.IdPropis == propis.Id
                                     select c).AsNoTracking().ToList();
                List<int> idClana = (from c in _context.ClanPP
                                     where c.IdPropis == id
                                     select c.Id).ToList();

                List<StavPP> stav = (from st in _context.StavPP
                                     where idClana.Contains(st.IdClan)
                                     select st).AsNoTracking().ToList();


                List<int> idStav = (from st in _context.StavPP
                                    where idClana.Contains(st.IdClan)
                                    select st.Id).ToList();

                List<TackaPP> tacka = (from tac in _context.TackaPP
                                       where idStav.Contains(tac.IdStav)
                                       select tac).AsNoTracking().ToList();


                List<AlinejaPP> alineja = (from a in _context.AlinejaPP
                                           where idStav.Contains(a.IdStav)
                                           select a).AsNoTracking().ToList();

                //IN AKTA VEZA
                List<ProsvetniPropisInAkta> vezeProsvetniPropisInAkta = (from v in _context.ProsvetniPropisInAkta
                                                                         where v.IdProsvetniPropis == id
                                                                         select v).AsNoTracking().ToList();

                List<int?> idVezeInAkta = (from v in _context.ProsvetniPropisInAkta
                                           where v.IdProsvetniPropis == id
                                           select v.IdInAkta).ToList();

                List<int?> idStavovaDis = (from st in _context.ProsvetniPropisInAkta
                                           where st.IdProsvetniPropis == id
                                           select st.IdStavPP).Distinct().ToList();

                List<int?> idTackeDis = (from t in _context.ProsvetniPropisInAkta
                                         where t.IdProsvetniPropis == id && t.IdTackaPP != 0
                                         select t.IdTackaPP).Distinct().ToList();

                List<InAkta> inAKta = (from inAk in _context.InAkta
                                       where idVezeInAkta.Contains(inAk.Id)
                                       select inAk).AsNoTracking().ToList();

                //SLUZBENO MISLJENJE VEZA
                List<ProsvetniPropisSluzbenoMisljenje> vezaPPSM = (from veza in _context.ProsvetniPropisSluzbenoMisljenje
                                                                   where veza.IdProsvetniPropis == id
                                                                   select veza).AsNoTracking().ToList();

                List<int?> idStavovaSMDis = (from st in _context.ProsvetniPropisSluzbenoMisljenje
                                             where st.IdProsvetniPropis == id
                                             select st.IdStavPP).ToList();

                List<int?> idSmVeza = (from veza in _context.ProsvetniPropisSluzbenoMisljenje
                                       where veza.IdProsvetniPropis == id
                                       select veza.IdSluzbenoMisljenje).ToList();
                List<SluzbenoMisljenje> sluzbenaMisljenja = (from sm in _context.SluzbenoMisljenje
                                                             where idSmVeza.Contains(sm.Id)
                                                             select sm).AsNoTracking().ToList();

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
                ProsvetniPropis propis = _context.ProsvetnIPropis.Find(id);
                SluzbenoMisljenje sm = _context.SluzbenoMisljenje.Find(idSm);
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