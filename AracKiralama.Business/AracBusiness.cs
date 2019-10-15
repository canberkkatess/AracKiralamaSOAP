
using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AracKiralama.BusinessLayer
{
    public class AracBusiness
    {
        UnitOfWork uow;
        public AracBusiness()
        {
           uow = new UnitOfWork(new AracContext());

        }
        

        public List<tblArac> sirketIdAraclariGetir(int sirketId)
        {
            List<tblArac> araclar = new List<tblArac>();
            araclar = uow.AracRepository.AraclariGetr(sirketId);
            return araclar;
        }

        public bool aracEkle(tblArac a)
        {
            try
            {
                uow.AracRepository.Add(a);
                uow.commit();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        
        public List<tblArac> araclariGetir()
        {
            try
            {
                List<tblArac> araclar = uow.AracRepository.GetAll();
                return araclar;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public tblArac araciGetir(int id)
        {
            try
            {
                tblArac arac = uow.AracRepository.GetById(id);
                return arac;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool aracGuncelle(tblArac a)
        {
            try
            {
                uow.AracRepository.Update(a);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool aracSil(tblArac a)
        {
            try
            {
                uow.AracRepository.Remove(a);
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
