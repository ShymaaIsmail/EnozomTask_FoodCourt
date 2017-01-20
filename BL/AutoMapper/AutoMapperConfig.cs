using AutoMapper;
using DBModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BL.AutoMapper
{

    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            //----------------- Store ---------------------//
            Mapper.CreateMap<StoreModel, Store>();

            Mapper.CreateMap<Store, StoreModel>().ForMember(

                 dest => dest.StoreLogo,
        opt => opt.MapFrom(src => System.Configuration.ConfigurationManager.AppSettings["UploadStoreFolder"] + src.StoreLogo)

                );
            Mapper.AssertConfigurationIsValid();


        }
    }

}
