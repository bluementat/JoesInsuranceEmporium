using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class ApplicationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index()
        {
            // Call to Lock Property
            // Call Appraisal. Returns appraised value on property
            // Call Quote for the Line of Business
            
            return View();
        }
    }
}
