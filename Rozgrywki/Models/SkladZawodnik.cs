using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rozgrywki.Models
{
    public class SkladZawodnik
    {
        public virtual int SkladID { get; set; }
        public virtual int ZawodnikID { get; set; }
    }
}