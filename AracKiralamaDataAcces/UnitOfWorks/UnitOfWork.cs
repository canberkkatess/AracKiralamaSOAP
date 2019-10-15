using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.Repositories.Abstract;
using AracKiralama.DataAcces.Repositories.Concrete;

namespace AracKiralama.DataAcces.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        //Repositories
        public IArac AracRepository { get; private set; }

        public IKiralama KiralamaRepository { get; private set; }

        public IMusteri MusteriRepository { get; private set; }

        public IPuan PuanRepository { get; private set; }

        public ISirket SirketRepository { get; private set; }

        public ITalep TalepRepository { get; private set; }

        private readonly AracContext _aracContext;
        private readonly KiralamaContext _kiralamaContext;
        private readonly MusteriContext _musteriContext;
        private readonly PuanContext _puanContext;
        private readonly SirketContext _sirketContext;
        private readonly TalepContext _talepContect;

        public UnitOfWork(AracContext context)
        {
            _aracContext = context;
            AracRepository = new AracRepository(_aracContext);

        }
        public UnitOfWork(MusteriContext context)
        {
            _musteriContext = context;
            MusteriRepository = new MusteriRepository(_musteriContext);

        }
        public UnitOfWork(KiralamaContext context)
        {
            _kiralamaContext = context;
            KiralamaRepository = new KiralamaRepository(_kiralamaContext);

        }
        public UnitOfWork(PuanContext context)
        {
            _puanContext = context;
            PuanRepository = new PuanRepository(_puanContext);

        }
        public UnitOfWork(SirketContext context)
        {
            _sirketContext = context;
            SirketRepository = new SirketRepository(_sirketContext);

        }
        public UnitOfWork(TalepContext context)
        {
            _talepContect = context;
            TalepRepository = new TalepRepository(_talepContect);

        }
        public void commit()
        {
            if (_aracContext!=null)
            {
                _aracContext.SaveChanges();
            }
            else if(_musteriContext!= null)
            {
                _musteriContext.SaveChanges();
            }
            else if (_kiralamaContext!=null)
            {
                _kiralamaContext.SaveChanges();
            }
            else if (_puanContext!=null)
            {
                _puanContext.SaveChanges();
            }
            else if (_sirketContext!=null)
            {
                _sirketContext.SaveChanges();
            }
            else if (_talepContect!=null)
            {
                _talepContect.SaveChanges();
            }
        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
