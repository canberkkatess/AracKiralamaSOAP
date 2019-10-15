using AracKiralama.DataAcces.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Concrete
{
    public class Repository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class
    {
        protected DbContext _context;
        private DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException("dbContext");
            _dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {

            _dbSet.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Remove(entity);

        }

        public void RemoveRange(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
