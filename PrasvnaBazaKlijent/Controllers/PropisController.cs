using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class PropisController : Controller
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
                IList<Propis> propisList = (from p in _context.Propis
                                            where p.IdPodrubrike == id
                                            orderby p.RedniBroj
                                            select new Propis() { Id = p.Id, 
                                                Naslov = p.Naslov, 
                                                GlasiloIdatumObjavljivanja = p.GlasiloIdatumObjavljivanja, 
                                                DatumPrestankaVerzije = p.DatumPrestankaVerzije, 
                                                DatumPrestankaVazenjaPropisa = p.DatumPrestankaVazenjaPropisa }).AsNoTracking().ToList();

                var propisiList = propisList.OrderByDescending(m => m.RedniBroj != null).ThenBy(m => m.RedniBroj == null);
                ViewBag.IdPodrubrika = id;
                return View(propisiList);
            }



        }


    }
}