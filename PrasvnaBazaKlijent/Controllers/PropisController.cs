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
    public class PropisController : Controller
    {
        //obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
     

        public IActionResult Index(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
                using(var _context = new obrazovn_AdminPanelContext()) { 
                var propis = (from p in _context.Propis
                             where p.IdPodrubrike == id
                             orderby p.RedniBroj
                             select new Propis() { Id = p.Id, Naslov = p.Naslov, GlasiloIdatumObjavljivanja = p.GlasiloIdatumObjavljivanja, DatumPrestankaVerzije = p.DatumPrestankaVerzije, DatumPrestankaVazenjaPropisa = p.DatumPrestankaVazenjaPropisa}).AsNoTracking().ToList();
                ViewBag.IdPodrubrika = id;
                return View(propis);
            }


            
        }

  
    }
}