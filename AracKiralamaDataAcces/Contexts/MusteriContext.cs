
using AracKiralama.Data;
using System.Data.Entity;


namespace AracKiralama.DataAcces.Contexts
{
    public class MusteriContext : IContext
    {
        public DbSet<tblMüsteri> Musteriler { get; set; }
    }
}
