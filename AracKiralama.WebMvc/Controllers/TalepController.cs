using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.WebMvc.Controllers
{
    public class TalepController : Controller
    {
        private AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient client = new AracKiralama.WebMvc.SoapService.AracKiralamaServiceSoapClient();
        // GET: Talep
        [HttpPost]
        public ActionResult kiralamaTalep(int kullaniciId,int aracId)
        {
           SoapService.tblTalep talep = new SoapService.tblTalep();
            talep.aracID = aracId;
            talep.müsteriID = kullaniciId;
            client.talepEkle(talep);

            return RedirectToAction("Anasayfa", "Anasayfa", new { area = "" });
        }

        [HttpPost]
        public ActionResult kiralamaOnay(int kullaniciId, int aracId)
        {
            SoapService.tblKiralama kiralama = new SoapService.tblKiralama();
            kiralama.alistarihi = DateTime.Now;
            kiralama.müsteriID = kullaniciId;
            kiralama.aracID = aracId;
            

            return RedirectToAction("Anasayfa", "Anasayfa", new { area = "" });
        }


        public ActionResult talepler(int sirketId)
        {
            List<SoapService.tblTalep> talepler = new List<SoapService.tblTalep>();
            talepler = client.talepGetAll();

            return View(talepler);
        }

    }
}