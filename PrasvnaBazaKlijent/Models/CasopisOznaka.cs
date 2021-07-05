﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrasvnaBazaKlijent.Models
{
    public class CasopisOznaka
    {
        public CasopisOznaka()
        {
            CasopisNaslov = new HashSet<CasopisNaslov>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public ICollection<CasopisNaslov> CasopisNaslov { get; set; }
    }
}