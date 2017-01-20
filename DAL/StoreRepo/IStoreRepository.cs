using DBModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.StoreRepo
{
    public interface IStoreRepository
    {

        IQueryable<Store> GetAllStores();

        IQueryable<Store> SearchStores(
            Expression<Func<Store, bool>> filter = null);

        Store GetStoreByID(int id);
        void InsertStore(Store storeObj);
        void UpdateStore(Store storeObj);

        void DeleteStore(int id);

        void SaveChanges();

    }

}
