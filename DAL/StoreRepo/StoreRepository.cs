using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Domain;
using System.Linq.Expressions;
using Repository.Repository;
using Repository.Unit_Work;
namespace DAL.StoreRepo
{
    public class StoreRepository : GenericRepository<Store>,IStoreRepository
    {
        public StoreRepository(IUnitOfWork uOw)
            : base(uOw)
        {
        }

        public IQueryable<Store> GetAllStores()
        {
            IQueryable<Store> stores = base.Get();
            return stores;
        }

        public IQueryable<Store> SearchStores(Expression<Func<Store, bool>> filter)
        {
            IQueryable<Store> stores = base.Get(filter);
            return stores;
        }
        public Store GetStoreByID(int id)
        {
            return base.GetByID(id);
        }
        public void InsertStore(Store storeObj)
        {
            base.Insert(storeObj);
        }

        public void UpdateStore(Store storeObj)
        {
            base.Update(storeObj);
        }

        public void DeleteStore(int id)
        {
            base.Delete(id);
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

    }
}
