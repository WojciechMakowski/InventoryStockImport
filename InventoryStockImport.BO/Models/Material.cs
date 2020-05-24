using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BO.Models
{
    public class Material
    {
        public string MaterialId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
