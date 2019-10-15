using AracKiralama.BusinessLayer;
using AracKiralama.Data;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AracKiralama.SOAP
{
    /// <summary>
    /// AracKiralamaService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
   
    public class AracKiralamaService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Merhaba Dünya";
        }

        //Musteri islemleri /////Musteri islemleri /////Musteri islemleri ///

        private MusteriBusiness musteri = new MusteriBusiness();
        [WebMethod]
        public int MusteriEkle(tblMüsteri a)
        {
            try
            {
               int deger = musteri.musteriEkle(a);
               return deger;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [WebMethod]
        public int musteriLogin(string kullaniciAdi, string pw)
        {
            return musteri.musteriGiris(kullaniciAdi, pw);
        }

        [WebMethod]
        public bool musteriDelete(tblMüsteri m)
        {
            return musteri.musteriSil(m);
        }

        [WebMethod]
        public List<tblMüsteri> musteriGetAll()
        {
            return musteri.musterileriGetir();
        }

        [WebMethod]
        public tblMüsteri musteriGetById(int id)
        {
            return musteri.musteriGetir(id);
        }

        [WebMethod]
        public bool musteriUpdate(tblMüsteri m)
        {
            return musteri.musteriGuncelle(m);
        }

        //Şirket islemleri /////Şirket islemleri /////Şirket islemleri ///

        private SirketBusiness sirket = new SirketBusiness();      
        [WebMethod]
        public int SirketEkle(tblSirket s)
        {
            try
            {
                int deger = sirket.sirketEkle(s);

                return deger;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [WebMethod]
        public int sirketlogin(string kullaniciAdi, string pw)
        {
            return sirket.sirketGiris(kullaniciAdi, pw);
        }

        [WebMethod]
        public bool sirketDelete(tblSirket s)
        {
            return sirket.sirketSil(s);
        }

        [WebMethod]
        public List<tblSirket> sirketGetAll()
        {
            return sirket.sirketleriGetir();
        }

        [WebMethod]
        public tblSirket sirketGetById(int id)
        {
            return sirket.sirketiGetir(id);
        }

        [WebMethod]
        public bool sirketUpdate(tblSirket s)
        {
            return sirket.sirketGuncelle(s);
        }


        //Araç islemleri /////Araç islemleri /////Araç islemleri ///

        private AracBusiness arac = new AracBusiness();

        [WebMethod]
        public List<tblArac> sirketIdAracGetir(int sirketId)
        {

            return arac.sirketIdAraclariGetir(sirketId);
        }

        
        [WebMethod]
        public bool AracEkle(tblArac a)
        {
            try
            {
                arac.aracEkle(a);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        [WebMethod]
        public bool AracDelete(tblArac a)
        {
            return arac.aracSil(a);
        }
        [WebMethod]
        public List<tblArac> aracGetAll()
        {
            return arac.araclariGetir();
        }

        [WebMethod]
        public tblArac aracGetById(int id)
        {
            return arac.araciGetir(id);
        }

        [WebMethod]
        public bool aracUpdate(tblArac a)
        {
            return arac.aracGuncelle(a);
        }

        //Kiralama islemleri /////Kiralama islemleri /////Kiralama islemleri ///

        private KiralamaBusiness kiralama = new KiralamaBusiness();


        [WebMethod]
        public bool KiralamaEkle(tblKiralama k)
        {
            try
            {
                kiralama.kiralamaEkle(k);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [WebMethod]
        public bool kiralamaDelete(tblKiralama k)
        {
            return kiralama.kiralamaSil(k);
        }
        [WebMethod]
        public List<tblKiralama> kiralamaGetAll()
        {
            return kiralama.kiralamalariGetir();
        }

        [WebMethod]
        public tblKiralama kiralamaGetById(int id)
        {
            return kiralama.kiralamaGetir(id);
        }

        [WebMethod]
        public bool kiralamaUpdate(tblKiralama k)
        {
            return kiralama.kiralamaGuncelle(k);
        }


        //Puan islemleri /////Puan islemleri /////Puan islemleri ///

        private PuanBusiness puan = new PuanBusiness();


        [WebMethod]
        public bool puanEkle(tblPuan p)
        {
            try
            {
                puan.puanEkle(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [WebMethod]
        public bool puanDelete(tblPuan p)
        {
            return puan.puanSil(p);
        }
        [WebMethod]
        public List<tblPuan> puanGetAll()
        {
            return puan.puanlamalariGetir();
        }

        [WebMethod]
        public tblPuan puanGetById(int id)
        {
            return puan.puanGetir(id);
        }

        [WebMethod]
        public bool puanUpdate(tblPuan p)
        {
            return puan.puanGuncelle(p);
        }

        //Talep islemleri /////Talep islemleri /////Talep islemleri ///

        private TalepBusiness talep = new TalepBusiness();


        [WebMethod]
        public bool talepEkle(tblTalep t)
        {
            try
            {
                talep.talepEkle(t);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [WebMethod]
        public bool talepDelete(tblTalep t)
        {
            return talep.talepSil(t);
        }
        [WebMethod]
        public List<tblTalep> talepGetAll()
        {
            return talep.talepleriGetir();
        }

        [WebMethod]
        public tblTalep talepGetById(int id)
        {
            return talep.talepGetir(id);
        }

        [WebMethod]
        public bool talepUpdate(tblTalep t)
        {
            return talep.talepGuncelle(t);
        }
    }
}
