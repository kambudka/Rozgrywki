using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class Druzyna
    {
        public virtual int DruzynaID { get; set; }
        public virtual int StatystykiDruzynyID { get; set; }
        public virtual int TypDruzynyID { get; set; }
        public virtual int SkladID { get; set; }
        public virtual string Nazwa { get; set; }
    }
}