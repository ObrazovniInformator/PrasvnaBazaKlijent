﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

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
                IList<ProsvetniPropis> propisList = (from p in _context.ProsvetnIPropis
                                                where p.IdPodrubrike == id
                                                orderby p.RedniBroj
                                                select new ProsvetniPropis() { Id = p.Id, 
                                                    Naslov = p.Naslov, GlasiloIDatumObjavljivanja = p.GlasiloIDatumObjavljivanja, 
                                                    DatumPrestankaVerzije = p.DatumPrestankaVerzije, 
                                                    DatumPrestankaVazenjaPropisa = p.DatumPrestankaVazenjaPropisa }).AsNoTracking().ToList();

                var propisiList = propisList.OrderByDescending(m => m.RedniBroj != null).ThenBy(m => m.RedniBroj == null);
                ViewBag.PodrubrikaPP = id;
                return View(propisiList);
            }
        }
    }
}
