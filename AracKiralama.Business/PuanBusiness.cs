using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AracKiralama.BusinessLayer
{
    public class PuanBusiness
    {
        private UnitOfWork uow;
        public PuanBusiness()
        {
            uow = new UnitOfWork(new PuanContext());
        }

        public bool puanEkle(tblPuan p)
        {
            try
            {
                uow.PuanRepository.Add(p);
                uow.commit();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<tblPuan> puanlamalariGetir()
        {
            try
            {
                List<tblPuan> puanlar = uow.PuanRepository.GetAll();
                return puanlar;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public tblPuan puanGetir(int id)
        {
            try
            {
                tblPuan puan = uow.PuanRepository.GetById(id);
                uow.commit();
                return puan;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool puanGuncelle(tblPuan p)
        {
            try
            {
                uow.PuanRepository.Update(p);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool puanSil(tblPuan p)
        {
            try
            {
                uow.PuanRepository.Remove(p);
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
