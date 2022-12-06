using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class DonosilacSm
    {
        public DonosilacSm()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
    }
}
