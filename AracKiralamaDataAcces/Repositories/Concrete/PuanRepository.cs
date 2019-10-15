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
    public class PuanRepository : Repository<tblPuan,int>,IPuan
    {
        private PuanContext _dbContext;

        public PuanRepository(PuanContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
