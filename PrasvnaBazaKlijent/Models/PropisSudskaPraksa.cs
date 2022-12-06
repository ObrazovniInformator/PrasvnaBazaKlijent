using System;

namespace PrasvnaBazaKlijent.Models
{
    public partial class PropisSudskaPraksa
    {
        public int Id { get; set; }
        public int IdPropis { get; set; }
        public int IdSudskaPraksa { get; set; }
        public int IdClan { get; set; }
        public int IdStav { get; set; }
        public int? IdTacka { get; set; }
        public DateTime? DatumUnosa { get; set; }
    }
}
