using AracKiralama.Data;
using System.Data.Entity;

namespace AracKiralama.DataAcces.Contexts
{
    public class AracContext : IContext
    {
        public DbSet<tblArac> Araclar { get; set; } 
    }
}
