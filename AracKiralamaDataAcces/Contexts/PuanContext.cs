
using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Contexts
{
    public class PuanContext : IContext
    {
        public DbSet<tblPuan> Puanlar { get; set; }
    }
}
