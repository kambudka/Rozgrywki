using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class StatystykiDruzyny
    {
        public virtual int StatystykiDruzynyID { get; set; }
        public virtual int IloscMeczy { get; set; }
        public virtual int IloscWygranychMeczy { get; set; }
    }
}