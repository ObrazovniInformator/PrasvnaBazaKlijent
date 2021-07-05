using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrasvnaBazaKlijent.Models
{
    public class PdfFajlCasopis
    {
        public int Id { get; set; }
        public string NaslovPdf { get; set; }
        public string PdfPath { get; set; }
        public int IdCasopis { get; set; }
        public CasopisNaslov IdCasopisNavigation { get; set; }
    }
}
