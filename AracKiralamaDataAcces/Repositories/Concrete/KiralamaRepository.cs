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
    public class KiralamaRepository : Repository<tblKiralama,int>,IKiralama
    {
        private KiralamaContext _dbContext;

        public KiralamaRepository(KiralamaContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
