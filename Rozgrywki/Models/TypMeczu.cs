using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class TypMeczu
    {
        public virtual int TypMeczuID { get; set; }
        public virtual int StatystykiTypuID { get; set; }
        public virtual string NazwaTypu { get; set; }
    }
}