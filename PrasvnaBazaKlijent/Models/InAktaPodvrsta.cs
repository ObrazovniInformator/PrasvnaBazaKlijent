using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class InAktaPodvrsta
    {
        public InAktaPodvrsta()
        {
            InAkta = new HashSet<InAkta>();
            RubrikaInAkta = new HashSet<RubrikaInAkta>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public ICollection<InAkta> InAkta { get; set; }
        public ICollection<RubrikaInAkta> RubrikaInAkta { get; set; }
    }
}
