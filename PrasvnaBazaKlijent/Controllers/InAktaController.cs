using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using Rotativa.AspNetCore;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class InAktaController : Controller
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
                List<InAkta> inAktas = (from i in _context.InAkta
                                        where i.IdPodpodrubrika == id
                                        select new InAkta() { Id = i.Id, Naslov = i.Naslov, DatumObjavljivanja = i.DatumObjavljivanja }).AsNoTracking().ToList();
                ViewBag.IdPodpodrubrike = id;
                return View(inAktas);
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
                //PROPISI
                List<PropisInAkta> vezePropis = (from veze in _context.PropisInAkta
                                                 where veze.IdInAkta == id
                                                 select veze).AsNoTracking().ToList();
                List<int?> idPropisList = (from veze in _context.PropisInAkta
                                           where veze.IdInAkta == id
                                           select veze.IdPropis).ToList();
                List<Propis> propisi = (from p in _context.Propis
                                        where idPropisList.Contains(p.Id)
                                        select p).AsNoTracking().ToList();
                ViewBag.VezePropis = vezePropis;
                ViewBag.Propisi = propisi;
                //PROSVETNI PROPISI VEZE
                List<ProsvetniPropisInAkta> vezeProsvetni = (from pp in _context.ProsvetniPropisInAkta
                                                             where pp.IdInAkta == id
                                                             select pp).AsNoTracking().ToList();
                List<int?> idPPVeze = (from pros in _context.ProsvetniPropisInAkta
                                       where pros.IdInAkta == id
                                       select pros.IdProsvetniPropis).ToList();
                List<ProsvetniPropis> prosvetniPropisi = (from prosp in _context.ProsvetnIPropis
                                                          where idPPVeze.Contains(prosp.Id)
                                                          select prosp).AsNoTracking().ToList();
                ViewBag.VezeProsvetni = vezeProsvetni;
                ViewBag.ProsvetniPropisi = prosvetniPropisi;

                InAkta inAkta = (from inak in _context.InAkta
                                 where inak.Id == id
                                 select inak).AsNoTracking().Single();
                return View(inAkta);
            }
        }
        [HttpGet]
        public IActionResult Stampaj(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                InAkta inAkta = _context.InAkta.Find(id);
                return new ViewAsPdf("Stampaj", inAkta);
            }
        }
        public IActionResult OtvoriVord(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                InAkta inAkta = _context.InAkta.Find(id);
                using (WordDocument document = new WordDocument())
                {
                    //Adds a section and a paragraph to the document
                    document.EnsureMinimal();
                    //Appends text to the last paragraph of the document
                    document.LastParagraph.AppendHTML(inAkta.Tekst);
                    MemoryStream stream = new MemoryStream();
                    //Saves the Word document to  MemoryStream
                    document.Save(stream, FormatType.Docx);
                    stream.Position = 0;
                    //Download Word document in the browser
                    return File(stream, "application/msword", inAkta.Naslov + ".docx");
                }
            }
        }
    }
}
