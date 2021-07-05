using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class ProsvetniPropisiController : Controller
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
                List<ProsvetniPropis> propis = (from p in _context.ProsvetnIPropis
                                                where p.IdPodrubrike == id
                                                orderby p.RedniBroj
                                                select new ProsvetniPropis() { Id = p.Id, Naslov = p.Naslov, GlasiloIDatumObjavljivanja = p.GlasiloIDatumObjavljivanja, DatumPrestankaVerzije = p.DatumPrestankaVerzije, DatumPrestankaVazenjaPropisa  = p.DatumPrestankaVazenjaPropisa}).AsNoTracking().ToList();
                ViewBag.PodrubrikaPP = id;
                return View(propis);
            }
        }
    }
}
