using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var res = new HttpResponseMessage(HttpStatusCode.OK);
            res.Content = new StringContent("Home");
            return res;
        }
    }
}
