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
    public class MusteriRepository : Repository<tblMüsteri, int>, IMusteri
    {
        
        private MusteriContext _dbContext;

        public MusteriRepository(MusteriContext context) : base(context)
        {
            _dbContext = context;
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

        public void kullaniciEkle(tblMüsteri a)
        {
            a.müsteriPassword = MD5eDonustur(a.müsteriPassword);
            _dbContext.Musteriler.Add(a);
            
        }
        public int ıdGetiAd(string ad)
        {
            var id = _dbContext.Musteriler.FirstOrDefault(x => x.müsteriAdi == ad);
            return id.müsteriID;
        }
        public int Login(string kullaniciAdi, string sifre)
        {
            var user = _dbContext.Musteriler.FirstOrDefault(x => x.müsteriAdi == kullaniciAdi);
            if (user != null)
            {
                if (user.müsteriPassword == MD5eDonustur(sifre))
                {
                    //kullanıcı ad pw doğru ise kullanıcı id döner
                    return user.müsteriID;
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
