using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class StatystykiZawodnika
    {
        public virtual int StatystykiZawodnikaID { get; set; }
        public virtual int IloscPunktow { get; set; }
        public virtual int IloscFauli { get; set; }
        public virtual int IloscGier { get; set; }
    }
}