using InventoryStockImport.BLL.Abstracts;
using InventoryStockImport.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryStockImport.BLL.Concrete
{
    public class ValidationService : IValidationService
    {
        public bool ValidateRawStock(string stock)
        {
            if (!stock.StartsWith("#")
                && StockHelper.GetPropertyCount(stock) == 3
                && !string.IsNullOrEmpty(StockHelper.GetMaterialName(stock))
                && !string.IsNullOrEmpty(StockHelper.GetMaterialID(stock)))
            {
                var warehouses = StockHelper.GetWarehouses(stock);
                if (warehouses.Length != 0)
                {
                    foreach (var item in warehouses)
                    {
                        if (string.IsNullOrEmpty(StockHelper.GetWarehouseName(item)) || string.IsNullOrEmpty(StockHelper.GetMaterialAmount(item)))
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if (!stock.StartsWith("#"))
                {
                    //w zadaniu nie bylo sprecyzowane co robic z blednymi liniami czy je poprawiac czy gdzies logowac
                    using (StreamWriter w = File.AppendText("importError.txt"))
                    {
                        w.WriteLine("Błąd importu w lini - {0}", stock);
                    }
           
                }
                return false;
            }
        }
    }
}
