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
    public class PrimeriKnjizenjaController : Controller
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
                List<PrimeriKnjizenja> primeriKnjizenja = (from pk in _context.PrimeriKnjizenja
                                                           where pk.IdRubrikaPK == id
                                                           select new PrimeriKnjizenja() { Id = pk.Id, Naslov = pk.Naslov, Podnaslov = pk.Podnaslov }).AsNoTracking().ToList();
                ViewBag.IdRubrika = id;
                ViewBag.PrimeriKnjizenja = primeriKnjizenja;
                return View();
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
                PrimeriKnjizenja pk = _context.PrimeriKnjizenja.Find(id);
                ViewBag.PK = pk;
                return View();
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
                PrimeriKnjizenja primeri = _context.PrimeriKnjizenja.Find(id);

                return new ViewAsPdf("Stampaj", primeri);
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
                PrimeriKnjizenja pk = _context.PrimeriKnjizenja.Find(id);
                using (WordDocument document = new WordDocument())
                {
                    //Adds a section and a paragraph to the document
                    document.EnsureMinimal();
                    //Appends text to the last paragraph of the document
                    document.LastParagraph.AppendHTML(pk.Tekst);
                    MemoryStream stream = new MemoryStream();
                    //Saves the Word document to  MemoryStream
                    document.Save(stream, FormatType.Docx);
                    stream.Position = 0;
                    //Download Word document in the browser
                    return File(stream, "application/msword", "PrimerKnjizenja.docx");
                }
            }
        }
    }
}
