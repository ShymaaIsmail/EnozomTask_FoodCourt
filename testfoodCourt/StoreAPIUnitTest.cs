using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodCourtWebAPI.Controllers;
using BL.StoreLogic;
using DAL.StoreRepo;
using Repository;
using Repository.Unit_Work;
using Repository.Unit_Work;
using ViewModel;
using BL.AutoMapper;
namespace testfoodCourt
{
    [TestClass]
    public class StoreAPIUnitTest
    {
        [TestInitialize]
        public void initializeConfigureAutoMapping()
        {
            //////register mapperes in the begining
            AutoMapperConfig.RegisterMappers();
        }

        [TestMethod]
        public void TestGetAllStoresAPI()
        {
            IUnitOfWork uOfw = new UnitofWork();
            StoreController ctrl = new StoreController(new StoreBL(new StoreRepository(uOfw)));
            var res = ctrl.GetAll();
        }
         [TestMethod]
        public void TestSearchAPI()
        {
            IUnitOfWork uOfw = new UnitofWork();
            StoreController ctrl = new StoreController(new StoreBL(new StoreRepository(uOfw)));
            var res = ctrl.SearchByName("store");
        }
        


        [TestMethod]
        public void TestAddStoreAPI()
        {
            IUnitOfWork uOfw = new UnitofWork();
            StoreController ctrl = new StoreController(new StoreBL(new StoreRepository(uOfw)));
            StoreModel modelToInsert = new StoreModel();
            modelToInsert.StoreName = "NEEEE Delaveg";
            modelToInsert.StoreDescription = "NEEDelavega Loran is an amazing place";
            modelToInsert.StoreLogo = "dddddasasa.png";
            var res = ctrl.AddStore(modelToInsert);
        }

        public void TestUpdateStoreAPI()
        {
            IUnitOfWork uOfw = new UnitofWork();
            StoreController ctrl = new StoreController(new StoreBL(new StoreRepository(uOfw)));
            StoreModel modelToUpdate = new StoreModel();
            modelToUpdate.StoreID = 18;
            modelToUpdate.StoreName = "Delavega Loran Updatedddddd Shymaa TEST";
            modelToUpdate.StoreDescription = "Updated Desc Delavega Loran is an amazing place :) :) :)";
            modelToUpdate.StoreLogo = "updatedLooggggoo.png";
            ctrl.EditStore(modelToUpdate);
        }

        public void TestDeleteStoreAPI()
        {
            IUnitOfWork uOfw = new UnitofWork();
            StoreController ctrl = new StoreController(new StoreBL(new StoreRepository(uOfw)));

            ctrl.DeleteStore(1);
        }
    }
}
