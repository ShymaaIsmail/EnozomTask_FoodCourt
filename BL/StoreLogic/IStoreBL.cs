using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BL.StoreLogic
{
    public interface IStoreBL
    {
        List<StoreModel> GetAll();
        List<StoreModel> searchByName(string strStoreName);
        StoreModel getStoreByID(int id);
        int AddStore(StoreModel storeModel);
        bool EditStore(StoreModel storeModel);
        bool DeleteStore(int id);
    }
}
