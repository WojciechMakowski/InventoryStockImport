using InventoryStockImport.BLL.Abstracts;
using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryStockImport.BLL.Concrete
{
    public class SortService : ISortService
    {
        public void SortMaterials(IDictionary<string, Warehouse> warehouse)
        {
            foreach (var item in warehouse)
            {
                item.Value.Materials = item.Value.Materials.OrderBy(x => x.MaterialId);
            }
        }

        public IDictionary<string, Warehouse> SortWarehouses(IDictionary<string, Warehouse> warehouse)
        {
            IDictionary<string, Warehouse> result = new Dictionary<string, Warehouse>();

            var group = warehouse.GroupBy(x => x.Value.TotalAmount);

            foreach (var item in group)
            {
                var orderedGroup = item.OrderByDescending(x => x.Value.Name);

                foreach (var item2 in orderedGroup)
                {
                    result.Add(item2.Key, item2.Value);
                }
            }
            return result;
        }
    }
}
