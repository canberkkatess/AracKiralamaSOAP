using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.UnitOfWorks;

using System;
using System.Collections.Generic;
using System.Text;

namespace AracKiralama.BusinessLayer
{
    public class SirketBusiness
    {
        private UnitOfWork uow = new UnitOfWork(new SirketContext());
        public int sirketEkle(tblSirket s)
        {
            try
            {
                uow.SirketRepository.kullaniciEkle(s);
                uow.commit();

                int id = uow.SirketRepository.ıdGetiAd(s.sirketAdi);
                if (id==0)
                {
                    return 0;
                }
                else
                {
                    return id;
                }

            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int sirketGiris(string kullaniciAdi, string password)
        {
            try
            {
                int deger = uow.SirketRepository.Login(kullaniciAdi, password);
                if (deger == 0)
                {
                    return 0;
                }
                else
                {
                    return deger;
                }


            }
            catch (Exception)
            {

                return 0;
            }
        }

        public List<tblSirket> sirketleriGetir()
        {
            try
            {
                List<tblSirket> sirketler = uow.SirketRepository.GetAll();
                return sirketler;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public tblSirket sirketiGetir(int id)
        {
            try
            {
                tblSirket sirket = uow.SirketRepository.GetById(id);
                return sirket;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool sirketGuncelle(tblSirket s)
        {
            try
            {
                uow.SirketRepository.Update(s);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool sirketSil(tblSirket s)
        {
            try
            {
                uow.SirketRepository.Remove(s);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
