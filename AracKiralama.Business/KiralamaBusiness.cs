using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AracKiralama.BusinessLayer
{
    public class KiralamaBusiness
    {
        private UnitOfWork uow;

        public KiralamaBusiness()
        {
            uow = new UnitOfWork(new KiralamaContext());
        }
        public bool kiralamaEkle(tblKiralama k)
        {
            try
            {
                uow.KiralamaRepository.Add(k);
                uow.commit();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<tblKiralama> kiralamalariGetir()
        {
            try
            {
                List<tblKiralama> kiralamalar = uow.KiralamaRepository.GetAll();
                return kiralamalar;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public tblKiralama kiralamaGetir(int id)
        {
            try
            {
                tblKiralama kiralama = uow.KiralamaRepository.GetById(id);
                return kiralama;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool kiralamaGuncelle(tblKiralama k)
        {
            try
            {
                uow.KiralamaRepository.Update(k);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool kiralamaSil(tblKiralama k)
        {
            try
            {
                uow.KiralamaRepository.Remove(k);
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
