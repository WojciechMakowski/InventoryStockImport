using InventoryStockImport.BLL.Abstracts;
using InventoryStockImport.BLL.Helpers;
using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Concrete
{
    public class StockBLL : IStockBLL
    {
        public IDictionary<string, Warehouse> GetWarehouses(string stock)
        {
            Dictionary<string, Warehouse> res = new Dictionary<string, Warehouse>();
            try
            {
                var materialName = StockHelper.GetMaterialName(stock);
                var materialId = StockHelper.GetMaterialID(stock);
                var warehouses = StockHelper.GetWarehouses(stock);

                foreach (var item in warehouses)
                {
                    Material tmpMaterial = new Material();
                    tmpMaterial.Name = materialName;
                    tmpMaterial.MaterialId = materialId;

                    var warehouseName = StockHelper.GetWarehouseName(item);
                    var materialAmount = StockHelper.GetMaterialAmount(item);

                    Warehouse tmpWarehouse = new Warehouse();
                    tmpWarehouse.Name = warehouseName;

                    int amount;
                    bool success = int.TryParse(materialAmount, out amount);
                    if (success)
                    {
                        tmpMaterial.Amount = amount;
                    }
                    else
                        throw new Exception();

                    tmpWarehouse.Materials = new List<Material>() { tmpMaterial };

                    res.Add(tmpWarehouse.Name, tmpWarehouse);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return res;
        }
    }
}
