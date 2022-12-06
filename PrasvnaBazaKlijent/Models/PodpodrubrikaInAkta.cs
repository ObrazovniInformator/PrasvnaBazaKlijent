using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public class PodpodrubrikaInAkta
    {

        public PodpodrubrikaInAkta()
        {
            InAkta = new HashSet<InAkta>();

        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodrubrika { get; set; }
        public PodrubrikaInAkta IdPodrubrikaInAktaNavigation { get; set; }
        public ICollection<InAkta> InAkta { get; set; }


    }
}
