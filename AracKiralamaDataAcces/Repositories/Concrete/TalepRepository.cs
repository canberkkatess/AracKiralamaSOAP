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
    public class TalepRepository : Repository<tblTalep,int>,ITalep
    {
        private TalepContext _dbContext;

        public TalepRepository(TalepContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
