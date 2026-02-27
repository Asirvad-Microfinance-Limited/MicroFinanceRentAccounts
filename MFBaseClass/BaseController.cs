using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    [Route("api/[controller]")]
   // [ServiceFilter(typeof(TokenValidator))]   
    public class BaseController : Controller
    {

        public BaseController()
        {

        }
    }
}
