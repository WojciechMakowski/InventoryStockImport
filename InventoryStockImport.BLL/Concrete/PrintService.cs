using InventoryStockImport.BLL.Abstracts;
using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Concrete
{
    public class PrintService : IPrintService
    {
        public void PrintWarehouses(IDictionary<string, Warehouse> warehouses)
        {
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine("{0} (total {1})", warehouse.Value.Name, warehouse.Value.TotalAmount);
                foreach (var material in warehouse.Value.Materials)
                {
                    Console.WriteLine("{0}: {1}", material.MaterialId, material.Amount);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
