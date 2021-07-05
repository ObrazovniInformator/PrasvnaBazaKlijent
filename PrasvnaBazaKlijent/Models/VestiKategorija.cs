using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
