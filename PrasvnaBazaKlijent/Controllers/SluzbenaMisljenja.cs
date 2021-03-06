using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using Rotativa.AspNetCore;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class SluzbenaMisljenja : Controller
    {
        //obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();

        public IActionResult Index(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                List<SluzbenoMisljenje> sluzbenaMisljenjas = (from sm in _context.SluzbenoMisljenje
                                                              where sm.IdRubrikaSm == id
                                                              select new SluzbenoMisljenje() { Id = sm.Id, Naslov = sm.Naslov, Podnaslov = sm.Podnaslov, DatumDonosenja = sm.DatumDonosenja}).AsNoTracking().ToList();
                ViewBag.Podrubrika = id;
                return View(sluzbenaMisljenjas);
            }
        }

        public IActionResult Prikaz(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                //VEZE PROPIS
                List<PropisSluzbenoMisljenje> vezePropis = (from propis in _context.PropisSluzbenoMisljenje
                                                            where propis.IdSluzbenoMisljenje == id
                                                            select propis).Distinct().AsNoTracking().ToList();

                List<int> idVezePropis = (from veza in _context.PropisSluzbenoMisljenje
                                          where veza.IdSluzbenoMisljenje == id
                                          select veza.IdPropis).Distinct().ToList();

                List<Propis> propisi = (from p in _context.Propis
                                        where idVezePropis.Contains(p.Id)
                                        select p).AsNoTracking().ToList();

                //VEZE PROSVETNI PROPIS
                List<int?> vezePP = (from pp in _context.ProsvetniPropisSluzbenoMisljenje
                                     where pp.IdSluzbenoMisljenje == id
                                     select pp.IdProsvetniPropis).ToList();
                List<ProsvetniPropis> prosvetniPropis = (from pp in _context.ProsvetnIPropis
                                                         where vezePP.Contains(pp.Id)
                                                         select pp).AsNoTracking().ToList();

                ViewBag.VezePropis = vezePropis;
                ViewBag.Propisi = propisi;
                ViewBag.IdPropisDis = idVezePropis;
                ViewBag.ProsvetniPropis = prosvetniPropis;
                SluzbenoMisljenje sluzbenoMisljenje = _context.SluzbenoMisljenje.Find(id);
                return View(sluzbenoMisljenje);
            }
        }

        public IActionResult Stampaj(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                SluzbenoMisljenje sluzbenoMisljenje = _context.SluzbenoMisljenje.Find(id);
                return new ViewAsPdf("Stampaj", sluzbenoMisljenje);
            }

        }
    }
}
