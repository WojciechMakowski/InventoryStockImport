using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryStockImport.BO.Models
{
    public class Warehouse
    {
        public string Name { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public int TotalAmount
        {
            get
            {
                return Materials.Sum(x => x.Amount);
            }
        }
    }
}
