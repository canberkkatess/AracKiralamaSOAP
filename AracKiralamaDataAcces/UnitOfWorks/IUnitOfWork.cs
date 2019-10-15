using AracKiralama.DataAcces.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.UnitOfWorks
{
    interface IUnitOfWork: IDisposable
    {
        IArac AracRepository { get; }
        IKiralama KiralamaRepository { get; }
        IMusteri MusteriRepository { get; }
        IPuan PuanRepository { get; }
        ISirket SirketRepository { get; }
        ITalep TalepRepository { get; }
        void commit();
    }   
}
