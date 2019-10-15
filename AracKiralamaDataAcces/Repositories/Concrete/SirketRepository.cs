using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.Repositories.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Concrete
{
    public class SirketRepository : Repository<tblSirket,int>,ISirket
    {
        private SirketContext _dbContext;

        public SirketRepository(SirketContext context) : base(context)
        {
            _dbContext = context;
        }
        public int ıdGetiAd(string ad)
        {
            var id = _dbContext.Sirketler.FirstOrDefault(x => x.sirketAdi == ad);
            return id.sirketID;
        }
        private string MD5eDonustur(string metin)
        {
            MD5CryptoServiceProvider pwd = new MD5CryptoServiceProvider();
            return Sifrele(metin, pwd);
        }

        private string Sifrele(string metin, HashAlgorithm alg)
        {
            byte[] bytDegeri = System.Text.Encoding.UTF8.GetBytes(metin);
            byte[] sifreliByte = alg.ComputeHash(bytDegeri);
            return Convert.ToBase64String(sifreliByte);
        }

        public void kullaniciEkle(tblSirket a)
        {
            a.sirketPassword = MD5eDonustur(a.sirketPassword);
            _dbContext.Sirketler.Add(a);

           
        }

        public int Login(string kullaniciAdi, string sifre)
        {
            var user = _dbContext.Sirketler.FirstOrDefault(x => x.sirketAdi == kullaniciAdi);
            if (user != null)
            {
                if (user.sirketPassword == MD5eDonustur(sifre))
                {
                    //kullanıcı ad pw doğru ise kullanıcı id döner
                    return user.sirketID;
                }
                else
                {
                    //Kullanıcı Var Pw yanlış 0 döner
                    return 0;

                }
            }
            else
            {

                //bu kullanıcı adında biri yoksa 0 döner
                return 0;
            }
        }
    }
}
