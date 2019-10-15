using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.Repositories.Concrete;
using AracKiralama.DataAcces.UnitOfWorks;

using System;
using System.Collections.Generic;
using System.Text;

namespace AracKiralama.BusinessLayer
{
    public class MusteriBusiness
    {
        private UnitOfWork uow = new UnitOfWork(new MusteriContext());
        public int musteriEkle(tblMüsteri m)
        {
            try
            {
                uow.MusteriRepository.kullaniciEkle(m);
                uow.commit();

                int deger = uow.MusteriRepository.ıdGetiAd(m.müsteriAdi);
                if (deger==0)
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
        public int musteriGiris(string kullaniciAdi,string password)
        {
            try
            {
                int deger = uow.MusteriRepository.Login(kullaniciAdi, password);
                if (deger==0)
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
        
        public List<tblMüsteri> musterileriGetir()
        {
            try
            {
                List<tblMüsteri> musteriler = uow.MusteriRepository.GetAll();
                return musteriler;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public tblMüsteri musteriGetir(int id)
        {
            try
            {
                tblMüsteri musteri = uow.MusteriRepository.GetById(id);
                return musteri;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool musteriGuncelle(tblMüsteri m)
        {
            try
            {
                uow.MusteriRepository.Update(m);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool musteriSil(tblMüsteri m)
        {
            try
            {
                uow.MusteriRepository.Remove(m);
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
