using System.Collections.Generic;

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
