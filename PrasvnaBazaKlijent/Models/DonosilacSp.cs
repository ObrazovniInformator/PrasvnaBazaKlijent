﻿using System.Collections.Generic;

namespace PrasvnaBazaKlijent.Models
{
    public partial class DonosilacSp
    {
        public DonosilacSp()
        {
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
