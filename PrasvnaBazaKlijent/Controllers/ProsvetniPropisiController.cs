using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using X.PagedList;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class ProsvetniPropisiController : Controller
    {
        public IActionResult Index(int id, int? page)
        {
            var pageNumber = page ?? 1;
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                IList<ProsvetniPropis> propisList = (from p in _context.ProsvetnIPropis
                                                     where p.IdPodrubrike == id
                                                     orderby p.RedniBroj descending
                                                     select new ProsvetniPropis()
                                                     {
                                                         Id = p.Id,
                                                         Naslov = p.Naslov,
                                                         GlasiloIDatumObjavljivanja = p.GlasiloIDatumObjavljivanja,
                                                         DatumPrestankaVerzije = p.DatumPrestankaVerzije,
                                                         DatumPrestankaVazenjaPropisa = p.DatumPrestankaVazenjaPropisa
                                                     }).AsNoTracking().ToList();

                var propisiList = propisList.OrderByDescending(m => m.RedniBroj).ThenBy(m => m.RedniBroj == null);
                ViewBag.PodrubrikaPP = id;
                return View(propisiList.ToPagedList(pageNumber, 10));
            }
        }
    }
}
