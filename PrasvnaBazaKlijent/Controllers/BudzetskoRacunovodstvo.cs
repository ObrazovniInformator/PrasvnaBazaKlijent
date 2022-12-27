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
    public class BudzetskoRacunovodstvo : Controller
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
                List<RubrikaCasopis> rubrikeCasopisBR = (from rbr in _context.RubrikaCasopis
                                                         where rbr.IdOblast == 1 && rbr.IdBroj == id
                                                         select rbr).AsNoTracking().ToList();

                List<CasopisNaslov> casopis = new List<CasopisNaslov>();
                List<PodrubrikaCasopis> podrubrike = new List<PodrubrikaCasopis>();
                foreach (RubrikaCasopis rc in rubrikeCasopisBR)
                {
                    List<PodrubrikaCasopis> pod = (from p in _context.PodrubrikaCasopis
                                                   where p.IdRubrika == rc.ID
                                                   select p).ToList();
                    List<CasopisNaslov> cn = (from cc in _context.CasopisNaslov
                                              where cc.IdRubrika == rc.ID
                                              select new CasopisNaslov() { Id = cc.Id, Naslov = cc.Naslov, IdRubrika = cc.IdRubrika, IdPodrubrika = cc.IdPodrubrika }).AsNoTracking().ToList();
                    casopis.AddRange(cn);
                    podrubrike.AddRange(pod);
                }

                ViewBag.Casopisi = casopis;
                ViewBag.Podrubrike = podrubrike;
                ViewBag.IdBroj = id;
                return View(rubrikeCasopisBR);
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
                CasopisNaslov casopis = _context.CasopisNaslov.Find(id);
                List<int?> idCasopisVeza = (from veza in _context.PropisCasopis
                                            where veza.IdCasopis == id
                                            select veza.IdPropis).ToList();
                List<Propis> vezaPropis = (from pr in _context.Propis
                                           where idCasopisVeza.Contains(pr.Id)
                                           select pr).ToList();
                List<PdfFajlCasopis> pdfFajlovi = (from pd in _context.PdfFajlCasopis
                                                   where pd.IdCasopis == id
                                                   select pd).ToList();
                CasopisBroj cb = (from cas in _context.CasopisBroj
                                  where cas.Id == casopis.IdBroj
                                  select cas).Single();
                ViewBag.VezaPropis = vezaPropis;
                ViewBag.PdfFajlovi = pdfFajlovi;
                ViewBag.CasopisBroj = cb;
                return View(casopis);
            }
        }

        public IActionResult CitajPdf(int id)
        {
            var _context = new obrazovn_AdminPanelContext();
            PdfFajlCasopis fajl = (from p in _context.PdfFajlCasopis
                                   where p.Id == id
                                   select p).SingleOrDefault();
            string putanja = fajl.PdfPath;
            return File(System.IO.File.ReadAllBytes(putanja), "application/pdf");
        }
    }
}
