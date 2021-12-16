using Microsoft.AspNetCore.Mvc;
using PropertyGenerationApi.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyGenerationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyGenerationController : ControllerBase
    {
        IRandomPropertyGenerator _generator { get; set; }

        public PropertyGenerationController(IRandomPropertyGenerator Generator)
        {
            _generator = Generator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProperty()
        {
            var result = await _generator.Generate();

            return Ok(result);
        }
    }
}
