using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAcces.Repositories.Abstract
{
    public interface IRepository<TEntity,in TKey> where TEntity : class
    {
        TEntity GetById(TKey id);

        List<TEntity> GetAll();

        void Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(List<TEntity> entities);

        void Update(TEntity entity);

    }
}
