using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Domain
{
    public class Store
    {
        public Store()
        {

        }
        public int StoreID { get; set; }

        public string StoreName { get; set; }
        public string StoreLogo { get; set; }
        public string StoreDescription { get; set; }
      
    }
}
