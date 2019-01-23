using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class Mecz
    {
        public virtual int MeczID { get; set; }
        public virtual int Druzyna1ID { get; set; }
        public virtual int Druzyna2ID { get; set; }
        public virtual int StatystykiMeczuID { get; set; }
        public virtual int TypMeczuID { get; set; }
        public virtual DateTime DataMeczu { get; set; }
        public virtual int WynikDruzyny1 { get; set; }
        public virtual int WynikDruzyny2 { get; set; }
    }
}