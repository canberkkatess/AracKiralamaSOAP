
using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Abstract
{
    public interface IArac : IRepository<tblArac,int>
    {
        List<tblArac> AraclariGetr(int sirketId);
    }
}
