using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using Rotativa.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using X.PagedList;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class SudskaPraksaController : Controller
    {
        //obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();

        public IActionResult Index(int id, int? page)
        {
            var pageNumber = page ?? 1;
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                List<SudskaPraksa> sudskePrakse = (from sp in _context.SudskaPraksa
                                                   where sp.IdRubrikaSp == id
                                                   select new SudskaPraksa() { Id = sp.Id, Naslov = sp.Naslov, Podnaslov = sp.Podnaslov, Datum = sp.Datum }).ToList();
                ViewBag.Podrubrika = id;
                return View(sudskePrakse.ToPagedList(pageNumber, 10));
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
                //VEZE PROPISI
                List<PropisSudskaPraksa> vezePropis = (from propis in _context.PropisSudskaPraksa
                                                       where propis.IdSudskaPraksa == id
                                                       select propis).AsNoTracking().ToList();
                List<int> idVezePropis = (from veza in _context.PropisSudskaPraksa
                                          where veza.IdSudskaPraksa == id
                                          select veza.IdPropis).ToList();
                List<Propis> propisi = (from p in _context.Propis
                                        where idVezePropis.Contains(p.Id)
                                        select p).AsNoTracking().ToList();
                ViewBag.VezePropis = vezePropis;
                ViewBag.Propisi = propisi;
                SudskaPraksa sp = _context.SudskaPraksa.Find(id);
                return View(sp);
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
                SudskaPraksa sudskaPraksa = _context.SudskaPraksa.Find(id);
                return new ViewAsPdf("Stampaj", sudskaPraksa);
            }
        }
    }
}
