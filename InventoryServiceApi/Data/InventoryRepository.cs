﻿using JoesInsuranceEmporium.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryServiceApi.Data
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Property> _properties { get; set; }

        public InventoryRepository()
        {
            _properties = new List<Property>();
        }

        public async Task<List<Property>> GetInventory()
        {
            return await Task.FromResult(_properties);
        }

        public async Task<Property> FindById(Guid Id)
        {
            return await Task.FromResult(_properties.First(p => p.Id == Id));
        }

        public async Task<Property> AddProperty(Property property)
        {
            if (_properties.Count < 100)
            {
                _properties.Add(property);
            }
            
            return await Task.FromResult(property);
        }
    }
}
