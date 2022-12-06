using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class VestiKategorija
    {
        public VestiKategorija()
        {
            Vest = new HashSet<Vest>();
        }
        public int Id { get; set; }
        public string NazivKategorije { get; set; }


        public ICollection<Vest> Vest { get; set; }
    }
}
