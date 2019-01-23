using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class StatystykiMeczu
    {
        public virtual int StatystykiMeczuID { get; set; }
        public virtual int IloscFauli { get; set; }
        public virtual int IloscKarnych { get; set; }
        public virtual int IloscRoznych { get; set; }
    }
}