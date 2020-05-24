using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Abstracts
{
    public interface IValidationService
    {
        bool ValidateRawStock(string stock);
    }
}
