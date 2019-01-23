using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class StatystykiTypu
    {
        public virtual int StatystykiTypuID { get; set; }
        public virtual int IloscMeczy { get; set; }
        public virtual int IloscPunktow { get; set; }
    }
}