using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class Alineja
    {
        public int Id { get; set; }
        public string NazivAlineje { get; set; }
        public string Tekst { get; set; }
        public int? IdStav { get; set; }
    }
}
