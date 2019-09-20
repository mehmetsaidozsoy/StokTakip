using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;


namespace StokTakip.Controllers
{
    public class UrunMusteriController : Controller
    {
        // GET: UrunMusteri
        StokDbEntities db = new StokDbEntities();
        public ActionResult Index()
        {
            List<SelectListItem> degerler1 = (from i in db.TBLURUNLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.URUNAD,
                                                  Value = i.URUNID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            List<SelectListItem> degerler2 = (from i in db.TBLURUNLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MARKA,
                                                  Value = i.URUNID.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            List<SelectListItem> degerler3 = (from i in db.TBLMUSTERILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MUSTERIAD,
                                                  Value = i.MUSTERIID.ToString()
                                              }).ToList();
            ViewBag.dgr3 = degerler3;
            List<SelectListItem> degerler4 = (from i in db.TBLMUSTERILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MUSTERISOYAD,
                                                  Value = i.MUSTERIID.ToString()
                                              }).ToList();
            ViewBag.dgr4 = degerler4;
            return View();
        }
        [HttpGet]
        public ActionResult YeniTeslim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniTeslim(int URUN,int MUSTERI, int ADET)
        {
            TBLTESLIMAT T = new TBLTESLIMAT();
            T.URUN = URUN;
            T.MUSTERI = MUSTERI;
            T.ADET = ADET;
            db.TBLTESLIMAT.Add(T);
            db.SaveChanges();
            return RedirectToAction("INDEX");
        }
    }
}