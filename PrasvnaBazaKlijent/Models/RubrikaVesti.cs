using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrasvnaBazaKlijent.Models
{
    public class RubrikaVesti
    {
        public RubrikaVesti()
        {
            Vest = new HashSet<Vest>();
        }
        public int Id { get; set; }
        public string NazivRubrike { get; set; }

        public ICollection<Vest> Vest { get; set; }
    }
}
