using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StokTakip.Models.Entity;

namespace StokTakip.Views.Teslim.ViewModel
{
    public class UrunMusteriViewModel
    {
        public TBLURUNLER UrunModel { get; set; }
        public TBLMUSTERILER MusteriModel { get; set; }
        public TBLTESLIMAT TeslimModel { get; set; }
    }
}