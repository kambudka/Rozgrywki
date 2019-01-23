using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class Zawodnik
    {
        public virtual int ZawodnikID { get; set; }
        public virtual int StatystykiZawodnikaID { get; set; }
        public virtual int Numer { get; set; }
        public virtual string Imie { get; set; }
        public virtual string Nazwisko { get; set; }
    }
}