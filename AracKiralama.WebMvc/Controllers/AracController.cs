using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace AracKiralama.WebMvc.Controllers
{
    public class AracController : Controller
    {
        private AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient client = new AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient();
        // GET: Urun
        public ActionResult aracGetir(int aracId)
        {
            AracKiralama.WebMvc.SoapService.tblArac arac = new AracKiralama.WebMvc.SoapService.tblArac();
            arac = client.aracGetById(aracId);
            return View(arac);
        }
        
        [HttpPost]
        public ActionResult kiralamaIstek(int urunId,int kullaniciID)
        {
            

            return RedirectToAction("Anasayfa", "Anasayfa");
        }
        public ActionResult urunEkleView()
        {
            return View();
        }

        public ActionResult aracEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult aracEkle(string marka,string model,int minEhliyetYasi,int minSurucuYasi,int gunlukKmSinir,string koltukSayi,int fiyat,string aciklama,int sirketId,string airbagDurumu,string aracKasaTipi,int aracKm,string fotoUrl)
        {
            try
            {
                SoapService.tblArac eklenecek = new SoapService.tblArac();
                eklenecek.airbagDurumu = airbagDurumu;
                eklenecek.aracAciklama = aciklama;
                eklenecek.aracKasaTipi = aracKasaTipi;
                eklenecek.aracKmsi = aracKm;
                eklenecek.aracMarka = marka;
                eklenecek.aracModel = model;
                eklenecek.minEhliyetYasi = minEhliyetYasi;
                eklenecek.minSürücüYasi = minSurucuYasi;
                eklenecek.günlükKmSiniri = gunlukKmSinir;
                eklenecek.günlükKiralamaFiyati = fiyat;
                eklenecek.sirketID = sirketId;
                eklenecek.aracFotograf = fotoUrl;
                bool durum = client.AracEkle(eklenecek);
                if (durum)
                {
                    return RedirectToAction("kurumsalAnasayfa", "Anasayfa", new { sirketId = Session["sirketId"] });
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("kurumsalAnasayfa", "Anasayfa", new { sirketId = Session["sirketId"] });
        }
        



    }
}