using System;
using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class PropisSluzbenoMisljenje
    {
        public int Id { get; set; }
        public int IdPropis { get; set; }
        public int IdSluzbenoMisljenje { get; set; }
        public int IdClan { get; set; }
        public int IdStav { get; set; }
        public int? IdTacka { get; set; }
        public DateTime? DatumUnosa { get; set; }
    }
}
