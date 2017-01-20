using Repository.Unit_Work;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal IUnitOfWork unitOFwork;
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(IUnitOfWork unitOFworkObj)
        {
            this.unitOFwork = unitOFworkObj;
            this.context = unitOFworkObj.GetContext();
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate != null)
            {


                var entry = context.Entry<TEntity>(entityToUpdate);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {

                    System.Data.Entity.Core.Objects.ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;

                    System.Data.Entity.Core.Objects.ObjectSet<TEntity> objSet = objContext.CreateObjectSet<TEntity>();

                    System.Data.Entity.Core.EntityKey entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entityToUpdate);

                    object foundEntity;

                    bool exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
                    if (foundEntity != null)
                    {
                        var attachedEntry = context.Entry(foundEntity);
                        attachedEntry.CurrentValues.SetValues(entityToUpdate);
                    }
                    else
                    {
                        entry.State = EntityState.Modified; // This should attach entity
                    }
                }
            }

        }


        public void SaveChanges()
        {
            unitOFwork.Save();
        }

    }

}
