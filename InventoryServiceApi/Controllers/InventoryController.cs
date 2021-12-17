using InventoryServiceApi.Data;
using JoesInsuranceEmporium.DataClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _propertyRepo;
        
        public InventoryController(IInventoryRepository repo)
        {
            _propertyRepo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            var result = await _propertyRepo.GetInventory();

            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProperty(Property property)
        {
            var result = await _propertyRepo.AddProperty(property);

            return Ok(result);
        }
    }
}
