
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Letgo.Controllers
{
    public class GirisController : Controller
    {

        private AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient client = new AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient();
        // GET: Giris
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult giris(string kullaniciAdi,string sifre)
        {
            try
            {
                int deger = client.musteriLogin(kullaniciAdi, sifre);
                if (deger==0)
                {
                    return RedirectToAction("Index/Giris");
                    
                }
                else
                {
                    Session["kullaniciId"] = deger;
                    return RedirectToAction("Anasayfa", "Anasayfa", new { area = "" });
                }
            }
            catch 
            {
                Console.WriteLine("Hata");
                
            }
           
            return RedirectToAction("Index/Giris");
        }
        [HttpPost]
        public ActionResult kayitOl(string name,string mail,string sifre)
        {
            try
            {
                
                AracKiralama.WebMvc.SoapService.tblMüsteri musteri = new AracKiralama.WebMvc.SoapService.tblMüsteri();
                musteri.müsteriAdi = name;
                musteri.müsteriEmail = mail;
                musteri.müsteriPassword = sifre;
                Session["kullaniciId"]=client.MusteriEkleAsync(musteri);
              
            }
            catch
            {
                Console.WriteLine("Hata");

            }
            
            return RedirectToAction("Index/Giris");


        }


        [HttpPost]
        public ActionResult kurumsalKayitOl(string sirketAdi, string mail, string sifre)
        {
            try
            {

                AracKiralama.WebMvc.SoapService.tblSirket sirket = new AracKiralama.WebMvc.SoapService.tblSirket();
                sirket.sirketAdi = sirketAdi;
                sirket.sirketEmail = mail;
                sirket.sirketPassword = sifre;
                Session["sirketId"] = client.SirketEkle(sirket);

            }
            catch
            {
                Console.WriteLine("Hata");

            }

            return RedirectToAction("Index/Giris");


        }

        [HttpPost]
        public ActionResult kurumsalGiris(string sirketAdi, string sifre)
        {
            try
            {
                int deger = client.sirketlogin(sirketAdi, sifre);
                if (deger == 0)
                {
                    return RedirectToAction("Index/Giris");

                }
                else
                {
                    Session["sirketId"] = deger;
                    return RedirectToAction("kurumsalAnasayfa", "Anasayfa", new {sirketId=deger});
                }
            }
            catch
            {
                Console.WriteLine("Hata");

            }

            return RedirectToAction("Index/Giris");
        }
    }
}