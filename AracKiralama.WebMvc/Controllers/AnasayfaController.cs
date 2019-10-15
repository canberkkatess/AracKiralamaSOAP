using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Controllers
{
    public class AnasayfaController : Controller
    {
        private AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient client = new AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient();
        // GET: Anasayfa
        public ActionResult Anasayfa()
        {
            List< AracKiralama.WebMvc.SoapService.tblArac> araclar = new List<AracKiralama.WebMvc.SoapService.tblArac>();
            araclar = client.aracGetAll();
           
            return View(araclar);
        }
        
       

        [HttpPost]
        public ActionResult profilGor(int kullaniciId)
        {
            AracKiralama.WebMvc.SoapService.tblMüsteri musteri = new AracKiralama.WebMvc.SoapService.tblMüsteri();
            musteri = client.musteriGetById(kullaniciId);

            return View(musteri);
        }

        public ActionResult kurumsalAnasayfa(int sirketId)
        {
            List<AracKiralama.WebMvc.SoapService.tblArac> araclar = new List<AracKiralama.WebMvc.SoapService.tblArac>();
            araclar = client.sirketIdAracGetir(sirketId);
            return View(araclar);
        }
    }
}