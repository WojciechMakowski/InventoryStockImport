using InventoryStockImport.BLL.Abstracts;
using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace InventoryStockImport.BLL.Concrete
{
    public class ImportService : IImportService
    {
        private readonly IStockBLL _stockBLL;
        private readonly IValidationService _validationService;

        public ImportService(IStockBLL stockBLL, IValidationService validationService)
        {
            _stockBLL = stockBLL;
            _validationService = validationService;
        }

        public IDictionary<string, Warehouse> ImportStocks(string filePath)
        {
            Dictionary<string, Warehouse> result = new Dictionary<string, Warehouse>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var isStockValidate = _validationService.ValidateRawStock(line);

                        if (isStockValidate)
                        {
                            var warehouses = _stockBLL.GetWarehouses(line);

                            foreach (var item in warehouses)
                            {
                                if (result.ContainsKey(item.Key))
                                {
                                    result[item.Key].Materials = result[item.Key].Materials.Concat(item.Value.Materials).ToList();
                                }
                                else
                                {
                                    result.Add(item.Key, item.Value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return result;
        }
    }
}
