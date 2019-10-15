
using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Abstract
{
    public interface IMusteri : IRepository<tblMüsteri,int>
    {
        void  kullaniciEkle(tblMüsteri m);
        int Login(string kullaniciAdi, string sifre);
        int ıdGetiAd(string ad);
    }
}
