using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace StokTakip.Controllers
{

    public class TeslimController : Controller
    {
        // GET: Teslim
        StokDbEntities db = new StokDbEntities();
        
        public ActionResult Index()
        {
            var dgr = db.TBLTESLIMAT.Include(x=>x.TBLURUNLER).Include(x=>x.TBLMUSTERILER).ToList();
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

            var must = db.TBLMUSTERILER.AsEnumerable().OrderBy(x => x.MUSTERIAD).Select(s => new {
                Text = string.Format("{0} {1}", s.MUSTERIAD, s.MUSTERISOYAD),
                Value = s.MUSTERIID
            }).ToList(); 
            ViewBag.Musteri = new SelectList(must, "Value", "Text");

            var urn = db.TBLURUNLER.Where(x=>x.STOK>0).AsEnumerable().OrderBy(x => x.URUNAD).Select(s => new {
                Text = string.Format("{0} Marka-{1}- Fiyatı:{2} {3} Adet", s.MARKA, s.URUNAD, s.FİYAT,s.STOK),
                Value = s.URUNID
            }).ToList();
            ViewBag.Urun = new SelectList(urn, "Value", "Text");

            return View(dgr);
        }
        public ActionResult SIL(int id)
        {
            var teslim = db.TBLTESLIMAT.Find(id);
            db.TBLTESLIMAT.Remove(teslim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TeslimatGetir(int? id)
        {
            var must = db.TBLMUSTERILER.AsEnumerable().OrderBy(x => x.MUSTERIAD).Select(s => new {
                Text = string.Format("{0} {1}", s.MUSTERIAD, s.MUSTERISOYAD),
                Value = s.MUSTERIID
            }).ToList();
            ViewBag.Musteri = new SelectList(must, "Value", "Text");

            var urn = db.TBLURUNLER.Where(x => x.STOK > 0).AsEnumerable().OrderBy(x => x.URUNAD).Select(s => new {
                Text = string.Format("{0} Marka-{1}- Fiyatı:{2} {3} Adet", s.MARKA, s.URUNAD, s.FİYAT, s.STOK),
                Value = s.URUNID
            }).ToList();
            ViewBag.Urun = new SelectList(urn, "Value", "Text");

            var tsl = db.TBLTESLIMAT.Find(id);
            return View("TeslimatGetir", tsl);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLTESLIMAT tt)
        {
            TBLTESLIMAT teslim = db.TBLTESLIMAT.Find(tt.TESLIMID);
            teslim.URUN = tt.URUN;
            teslim.MUSTERI = tt.MUSTERI;
            teslim.ADET = tt.ADET;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult YeniTeslim(int Musteri,int Urun, int Adet)
        {
            TBLURUNLER u = db.TBLURUNLER.Where(x => x.URUNID == Urun).FirstOrDefault();
            TBLTESLIMAT t = new TBLTESLIMAT();

            if (u.STOK>=Adet)
            {
                t.ADET = Adet;
                t.MUSTERI = Musteri;
                t.URUN = Urun;

                db.TBLTESLIMAT.Add(t);
                db.SaveChanges();

                if (u != null)
                {
                    u.STOK = u.STOK - Adet;
                }
                db.SaveChanges();
            }
            else
            {
                TempData["mesaj"] = "stok yetersiz";
            }
            
            return RedirectToAction("Index");
        }
    }
}