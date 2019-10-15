using System.Data.Entity;

namespace AracKiralama.DataAcces.Contexts
{
    public abstract class IContext : DbContext
    {
        public IContext() : base("SOAEntities")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
    }
}
