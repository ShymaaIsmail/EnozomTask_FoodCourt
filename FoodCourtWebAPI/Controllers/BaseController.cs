using FoodCourtWebAPI.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodCourtWebAPI.Controllers
{
    [APIExceptionFilter]
    public class BaseController : ApiController
    {
    }
}
