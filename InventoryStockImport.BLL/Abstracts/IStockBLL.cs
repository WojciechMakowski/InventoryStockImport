using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Abstracts
{
    public interface IStockBLL
    {
        IDictionary<string ,Warehouse> GetWarehouses(string stock);
    }
}
