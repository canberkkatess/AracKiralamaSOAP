using AracKiralama.Data;
using AracKiralama.DataAcces.Contexts;
using AracKiralama.DataAcces.Repositories.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Concrete
{
    public class AracRepository : Repository<tblArac,int>,IArac
    {
        private AracContext _dbContext;

        public AracRepository(AracContext context) : base(context)
        {
            _dbContext = context;
        }

        public List<tblArac> AraclariGetr(int sirketId)
        {
            List<tblArac> araclar = new List<tblArac>();

            foreach (var item in _dbContext.Araclar)
            {
                if (item.sirketID==sirketId)
                {
                    araclar.Add(item);
                }
            }
            return araclar;
        }

    }
}
