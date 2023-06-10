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
    public class TekstPropisaController : Controller
    {
        public IActionResult Index(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            using (var _context = new obrazovn_AdminPanelContext())
            {
                var propisQuery = _context.Propis
                    .AsNoTracking()
                    .SingleOrDefault(pr => pr.Id == id);

                var pdfFajloviQuery = _context.PdfFajlPropis
                    .Where(pd => pd.IdPropis == id)
                    .ToList();

                var podnaslovQuery = _context.Podnaslov
                    .AsNoTracking()
                    .Where(p => p.IdPropis == propisQuery.Id)
                    .ToList();

                var clanQuery = _context.Clan
                    .AsNoTracking()
                    .Where(c => c.IdPropis == propisQuery.Id)
                    .ToList();

                var clanIdQuery = _context.Clan
                    .Where(c => c.IdPropis == propisQuery.Id)
                    .Select(c => c.Id)
                    .ToList();

                var stavQuery = _context.Stav
                    .AsNoTracking()
                    .Where(s => clanIdQuery.Contains((int)s.IdClan))
                    .ToList();

                var stavIdQuery = _context.Stav
                    .Where(s => clanIdQuery.Contains((int)s.IdClan))
                    .Select(s => s.Id)
                    .ToList();

                var tackaQuery = _context.Tacka
                    .AsNoTracking()
                    .Where(s => stavIdQuery.Contains((int)s.IdStav))
                    .ToList();

                var alinejaQuery = _context.Alineja
                    .AsNoTracking()
                    .Where(s => stavIdQuery.Contains((int)s.IdStav))
                    .ToList();

                var vezeSluzbenoMisljenjeQuery = _context.PropisSluzbenoMisljenje
                    .Where(v => v.IdPropis == id)
                    .Distinct()
                    .AsNoTracking()
                    .ToList();

                var idVezeSmQuery = _context.PropisSluzbenoMisljenje
                    .Where(veza => veza.IdPropis == id)
                    .Select(veza => veza.IdSluzbenoMisljenje)
                    .Distinct()
                    .ToList();

                var idStavovaDisQuery = _context.PropisSluzbenoMisljenje
                    .Where(st => st.IdPropis == id)
                    .Select(st => st.IdStav)
                    .Distinct()
                    .ToList();

                var sluzbenaMisljenjaQuery = _context.SluzbenoMisljenje
                    .Where(sm => idVezeSmQuery.Contains(sm.Id))
                    .AsNoTracking()
                    .ToList();

                var vezeInAktaQuery = _context.PropisInAkta
                    .Where(ina => ina.IdPropis == id)
                    .AsNoTracking()
                    .ToList();

                var vezeIdInAktaQuery = _context.PropisInAkta
                    .Where(veza => veza.IdPropis == id)
                    .Select(veza => veza.IdInAkta)
                    .Distinct()
                    .ToList();

                var inAktaQuery = _context.InAkta
                    .Where(i => vezeIdInAktaQuery.Contains(i.Id))
                    .AsNoTracking()
                    .ToList();

                var idStavovaInAktaDisQuery = _context.PropisInAkta
                    .Where(ina => ina.IdPropis == id)
                    .Select(ina => ina.IdStav)
                    .Distinct()
                    .ToList();

                var vezeSudskaPraksaQuery = _context.PropisSudskaPraksa
                    .Where(sp => sp.IdPropis == id)
                    .AsNoTracking()
                    .ToList();

                var vezeIdSpQuery = _context.PropisSudskaPraksa
                    .Where(veza => veza.IdPropis == id)
                    .Select(veza => veza.IdSudskaPraksa)
                    .ToList();

                var sudskaPraksaQuery = _context.SudskaPraksa
                    .Where(sp => vezeIdSpQuery.Contains(sp.Id))
                    .AsNoTracking()
                    .ToList();

                var idStavovaSPQuery = _context.PropisSudskaPraksa
                    .Where(spv => spv.IdPropis == id)
                    .Select(spv => spv.IdStav)
                    .Distinct()
                    .ToList();

                ViewBag.Propis = propisQuery;
                ViewBag.PdfFajlovi = pdfFajloviQuery;
                ViewBag.Podnaslovi = podnaslovQuery;
                ViewBag.Clanovi = clanQuery;
                ViewBag.Stavovi = stavQuery;
                ViewBag.Tacke = tackaQuery;
                ViewBag.Alineje = alinejaQuery;

                //SLUZBENO MISLJENJE
                ViewBag.VezeSluzbenoMisljenje = vezeSluzbenoMisljenjeQuery;
                ViewBag.IdStavovaDis = idStavovaDisQuery;
                ViewBag.SluzbenaMisljenja = sluzbenaMisljenjaQuery;

                //INAKTA
                ViewBag.VezeInAkta = vezeInAktaQuery;
                ViewBag.InAkta = inAktaQuery;
                ViewBag.InAktaStavoviDis = idStavovaInAktaDisQuery;

                //SUDSKA PRAKSA
                ViewBag.VezeSudskaPraksa = vezeSudskaPraksaQuery;
                ViewBag.SudskaPraksa = sudskaPraksaQuery;
                ViewBag.SPStavoviDis = idStavovaSPQuery;

                return View();
            }
        }

        [HttpGet]
        public IActionResult VezaPropisSm(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            using (var _context = new obrazovn_AdminPanelContext())
            {
                var propisQuery = _context.Propis.Find(id);
                var smQuery = _context.SluzbenoMisljenje.Find(idSm);

                var podnaslovQuery = _context.Podnaslov
                    .Where(p => p.IdPropis == propisQuery.Id)
                    .AsNoTracking()
                    .ToList();

                var clanQuery = _context.Clan
                    .Where(c => c.IdPropis == propisQuery.Id)
                    .AsNoTracking()
                    .ToList();

                var clanIdQuery = _context.Clan
                    .Where(c => c.IdPropis == propisQuery.Id)
                    .Select(c => c.Id)
                    .ToList();

                var stavQuery = _context.Stav
                    .Where(st => clanIdQuery.Contains((int)st.IdClan))
                    .AsNoTracking()
                    .ToList();

                var stavIdQuery = _context.Stav
                    .Where(s => clanIdQuery.Contains((int)s.IdClan))
                    .Select(s => s.Id)
                    .ToList();

                var tackaQuery = _context.Tacka
                    .Where(tac => stavIdQuery.Contains((int)tac.IdStav))
                    .AsNoTracking()
                    .ToList();

                var alinejaQuery = _context.Alineja
                    .Where(a => stavIdQuery.Contains((int)a.IdStav))
                    .AsNoTracking()
                    .ToList();

                ViewBag.Propis = propisQuery;
                ViewBag.SluzbenoMisljenje = smQuery;
                ViewBag.Podnaslovi = podnaslovQuery;
                ViewBag.Clanovi = clanQuery;
                ViewBag.Stavovi = stavQuery;
                ViewBag.Tacke = tackaQuery;
                ViewBag.Alineje = alinejaQuery;

                return View();
            }
        }

        [HttpGet]
        public IActionResult VezaPropisInAkta(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            using (var _context = new obrazovn_AdminPanelContext())
            {
                var pQuery = _context.Propis.Find(id);

                var podnasloviQuery = _context.Podnaslov
                    .Where(pd => pd.IdPropis == id)
                    .AsNoTracking()
                    .ToList();

                var clanoviQuery = _context.Clan
                    .Where(cl => cl.IdPropis == id)
                    .AsNoTracking()
                    .ToList();

                var idClanovaQuery = _context.Clan
                    .Where(cl => cl.IdPropis == id)
                    .Select(cl => cl.Id)
                    .ToList();

                var stavoviQuery = _context.Stav
                    .Where(st => idClanovaQuery.Contains((int)st.IdClan))
                    .AsNoTracking()
                    .ToList();

                var idStavovaQuery = _context.Stav
                    .Where(st => idClanovaQuery.Contains((int)st.IdClan))
                    .Select(st => st.Id)
                    .ToList();

                var tackeQuery = _context.Tacka
                    .Where(tac => idStavovaQuery.Contains((int)tac.IdStav))
                    .AsNoTracking()
                    .ToList();

                var alinejeQuery = _context.Alineja
                    .Where(al => idStavovaQuery.Contains((int)al.IdStav))
                    .AsNoTracking()
                    .ToList();

                var inAktaQuery = _context.InAkta
                    .Where(iina => iina.Id == idSm)
                    .AsNoTracking()
                    .Single();

                ViewBag.Propis = pQuery;
                ViewBag.InAkta = inAktaQuery;
                ViewBag.Podnaslovi = podnasloviQuery;
                ViewBag.Clanovi = clanoviQuery;
                ViewBag.Stavovi = stavoviQuery;
                ViewBag.Tacke = tackeQuery;
                ViewBag.Alineje = alinejeQuery;

                return View();
            }
        }

        [HttpGet]
        public IActionResult VezaPropisSP(int id, int idSm)
        {
            using var _context = new obrazovn_AdminPanelContext();

            Propis p = _context.Propis.Find(id);

            List<Podnaslov> podnaslovi = _context.Podnaslov
                .Where(pd => pd.IdPropis == id)
                .AsNoTracking()
                .ToList();

            List<Clan> clanovi = _context.Clan
                .Where(cl => cl.IdPropis == id)
                .AsNoTracking()
                .ToList();

            List<int> idClanova = clanovi.Select(cl => cl.Id).ToList();

            List<Stav> stavovi = _context.Stav
                .Where(st => idClanova.Contains((int)st.IdClan))
                .AsNoTracking()
                .ToList();

            List<int> idStavova = stavovi.Select(st => st.Id).ToList();

            List<Tacka> tacke = _context.Tacka
                .Where(tac => idStavova.Contains((int)tac.IdStav))
                .AsNoTracking()
                .ToList();

            List<Alineja> alineje = _context.Alineja
                .Where(al => idStavova.Contains((int)al.IdStav))
                .AsNoTracking()
                .ToList();

            SudskaPraksa sudskaPraksa = _context.SudskaPraksa
                .Where(sp => sp.Id == idSm)
                .AsNoTracking()
                .Single();

            ViewBag.Propis = p;
            ViewBag.SudskaPraksa = sudskaPraksa;
            ViewBag.Podnaslovi = podnaslovi;
            ViewBag.Clanovi = clanovi;
            ViewBag.Stavovi = stavovi;
            ViewBag.Tacke = tacke;
            ViewBag.Alineje = alineje;

            return View();
        }

        public IActionResult StampajPropis(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))

            using (var _context = new obrazovn_AdminPanelContext())
            {
                Propis propis = _context.Propis.Find(id);
                return new ViewAsPdf("StampajPropis", propis);
            }
        }

        public IActionResult CitajPdf(int id)
        {
            var _context = new obrazovn_AdminPanelContext();

            PdfFajlPropis fajl = (from p in _context.PdfFajlPropis
                                  where p.Id == id
                                  select p).SingleOrDefault();
            string putanja = fajl.PdfPath;
            return File(System.IO.File.ReadAllBytes(putanja), "application/pdf");
        }
    }
}