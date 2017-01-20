using BL.StoreLogic;
using FoodCourtWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel;

namespace FoodCourtWebAPI.Controllers
{
    public class StoreController : BaseController
    {
        IStoreBL storeBL;
        public StoreController(IStoreBL storeBLObj)
        {
            storeBL = storeBLObj;
        }

        [HttpGet]
        public WebAPIResult GetAll()
        {
            WebAPIResult res = new WebAPIResult();
            res.result= storeBL.GetAll();
            res.bSucessfulOperation = true;
            return res;
        }
        [HttpGet]
        public WebAPIResult SearchByName(string strStoreName)
        {

            WebAPIResult res = new WebAPIResult();
            res.result = storeBL.searchByName(strStoreName);
            res.bSucessfulOperation = true;
            return res;
        }
        [HttpGet]
        public WebAPIResult GetById(int id)
        {
            WebAPIResult res = new WebAPIResult();
            res.result = storeBL.getStoreByID(id);
            res.bSucessfulOperation = true;
            return res;
        }
        [HttpPost]
        public WebAPIResult AddStore(StoreModel storeModel)
        {
            WebAPIResult res = new WebAPIResult();
            res.result = storeBL.AddStore(storeModel);
            res.bSucessfulOperation = true;
            return res;
        }
        [HttpPost]
        public WebAPIResult EditStore(StoreModel storeModel)
        {
            WebAPIResult res = new WebAPIResult();
            res.result = storeBL.EditStore(storeModel);
            res.bSucessfulOperation = true;
            return res;
        }
        [HttpDelete]
        public WebAPIResult DeleteStore(int id)
        {
            WebAPIResult res = new WebAPIResult();
            res.result = storeBL.DeleteStore(id);
            res.bSucessfulOperation = true;
            return res;
        }

    }
}
