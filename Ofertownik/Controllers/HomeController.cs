using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
   
    public abstract class HomeController : ApiController
    {
      
       public IActionResult Get()
        {
            return Ok("Działa");
        }
    }
}
