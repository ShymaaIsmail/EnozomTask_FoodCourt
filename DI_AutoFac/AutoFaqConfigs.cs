using Autofac;
using BL.StoreLogic;
using DAL.StoreRepo;
using Repository.Unit_Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_AutoFac
{
    public class AutoFaqConfigs
    {
        public static ContainerBuilder Register(ContainerBuilder builder)
        {
            #region UnitOfWork (singleton unit of work to share DB)
            builder.RegisterType<UnitofWork>().As<IUnitOfWork>().SingleInstance();
            #endregion

            #region Repository
            builder.RegisterType<StoreRepository>().As<IStoreRepository>().InstancePerRequest();
            #endregion


            #region BL
            builder.RegisterType<StoreBL>().As<IStoreBL>().InstancePerRequest();
            #endregion
            return builder;
        }
    }
}
