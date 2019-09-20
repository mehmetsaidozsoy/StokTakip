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
    public class MusteriController : Controller
    {
        // GET: Musteri
        StokDbEntities db = new StokDbEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLMUSTERILER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View(p1);

        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);

        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}