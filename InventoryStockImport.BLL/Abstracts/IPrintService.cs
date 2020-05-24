using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Abstracts
{
    public interface IPrintService
    {
        void PrintWarehouses(IDictionary<string, Warehouse> warehouses);
    }
}
