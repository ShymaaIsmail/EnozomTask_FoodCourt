using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null);

          TEntity GetByID(object id);
          void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
        
        void SaveChanges();
    }
}
