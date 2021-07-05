using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrasvnaBazaKlijent.Models
{
    public class AlinejaPP
    {
        public int Id { get; set; }
        public string NazivAlineje { get; set; }
        public string Tekst { get; set; }
        public int IdStav { get; set; }

        public StavPP IdStavNavigation { get; set; }
    }
}
