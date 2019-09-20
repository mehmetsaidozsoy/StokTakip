using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace StokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        StokDbEntities db = new StokDbEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLURUNLER.Include("TBLKATEGORILER").ToList().ToPagedList(sayfa,4);

            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniUrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrunEkle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("Urungetir",urn);
        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            TBLURUNLER urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            //urn.URUNKATEGORI = p.URUNKATEGORI;
            urun.FİYAT = p.FİYAT;
            urun.STOK = p.STOK;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}