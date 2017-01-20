using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodCourtWebAPI.Models
{
    public class WebAPIResult
    {
        public bool bSucessfulOperation { get; set; }
        public dynamic result { get; set; }

    }
}