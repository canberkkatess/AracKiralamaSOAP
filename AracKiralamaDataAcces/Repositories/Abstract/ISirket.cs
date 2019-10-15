
using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Abstract
{
    public interface ISirket : IRepository<tblSirket,int>
    {
        void kullaniciEkle(tblSirket m);
        int Login(string kullaniciAdi, string sifre);
        int ıdGetiAd(string ad);
    }
}
