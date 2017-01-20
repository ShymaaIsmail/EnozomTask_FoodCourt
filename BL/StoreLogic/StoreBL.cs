using AutoMapper;
using DAL.StoreRepo;
using DBModel.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BL.StoreLogic
{
    public class StoreBL : IStoreBL
    {
        IStoreRepository StoreRepo;
        public StoreBL(IStoreRepository StoreRepoObj)
        {

            StoreRepo = StoreRepoObj;
        }
        public List<StoreModel> GetAll()
        {

            List<Store> stores = StoreRepo.GetAllStores().ToList();
            List<StoreModel> lstStores = Mapper.Map<List<Store>, List<StoreModel>>(stores);
            return lstStores;
        }
        public List<StoreModel> searchByName(string strStoreName)
        {
            List<Store> stores = StoreRepo.SearchStores(a => a.StoreName.ToLower().Contains(strStoreName.ToLower())).ToList();
            List<StoreModel> lstStores = Mapper.Map<List<Store>, List<StoreModel>>(stores);
            return lstStores;
        }
        public StoreModel getStoreByID(int id)
        {
            var store = StoreRepo.GetStoreByID(id);
            StoreModel storeModel = Mapper.Map<Store, StoreModel>(store);
            return storeModel;
        }
        public int AddStore(StoreModel storeModel)
        {
            int iInserstedID = 0;
            Store storeObj = Mapper.Map<StoreModel, Store>(storeModel);
            StoreRepo.InsertStore(storeObj);
            StoreRepo.SaveChanges();
            iInserstedID = storeObj.StoreID;

            return iInserstedID;
        }
        public bool EditStore(StoreModel storeModel)
        {
            bool isUpdated = false;

            Store storeObj = Mapper.Map<StoreModel, Store>(storeModel);
            StoreRepo.UpdateStore(storeObj);
            StoreRepo.SaveChanges();
            isUpdated = true;

            return isUpdated;
        }
        public bool DeleteStore(int id)
        {
            bool isDeleted = false;

            StoreRepo.DeleteStore(id);
            StoreRepo.SaveChanges();
            isDeleted = true;

            return isDeleted;
        }

    }
}
