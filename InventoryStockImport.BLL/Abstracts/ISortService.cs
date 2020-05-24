using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Abstracts
{
    public interface ISortService
    {
        void SortMaterials(IDictionary<string, Warehouse> warehouse);
        IDictionary<string, Warehouse> SortWarehouses(IDictionary<string, Warehouse> warehouse);
    }
}
