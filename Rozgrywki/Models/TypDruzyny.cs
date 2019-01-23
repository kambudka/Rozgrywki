using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class TypDruzyny
    {
        public virtual int TypDruzynyID { get; set; }
        public virtual string NazwaTypu { get; set; }
    }
}