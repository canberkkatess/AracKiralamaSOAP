using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AracKiralama.BusinessLayer
{
    public class TalepBusiness
    {
        private UnitOfWork uow = new UnitOfWork(new TalepContext());

        public TalepBusiness()
        {
            
        }

        public bool talepEkle(tblTalep t)
        {
            try
            {
                uow.TalepRepository.Add(t);
                uow.commit();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<tblTalep> talepleriGetir()
        {
            try
            {
                List<tblTalep> talepler = uow.TalepRepository.GetAll();
                return talepler;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public tblTalep talepGetir(int id)
        {
            try
            {
                tblTalep talep = uow.TalepRepository.GetById(id);
                return talep;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool talepGuncelle(tblTalep t)
        {
            try

            {
                uow.TalepRepository.Update(t);
                uow.commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool talepSil(tblTalep t)
        {
            try
            {
                uow.TalepRepository.Remove(t);
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
