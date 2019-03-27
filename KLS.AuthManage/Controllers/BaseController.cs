using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace KLS.AuthManage.Controllers
{
    //基类Controller
    public class BaseController : ApiController
    {
        public readonly int PAGE_SIZE = 20;
    }
}
