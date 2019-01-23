using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public virtual DateTime DataMeczu { get; set; }
        public virtual int WynikDruzyny1 { get; set; }
        public virtual int WynikDruzyny2 { get; set; }
    }
}