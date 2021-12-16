using JoesInsuranceEmporium.DataClasses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryServiceApi.Data
{
    public interface IInventoryRepository
    {
        Task<Property> FindById(Guid Id);
        Task<List<Property>> GetInventory();

        Task<Property> AddProperty(Property property);
    }
}