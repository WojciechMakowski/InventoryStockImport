using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryStockImport.BLL.Helpers
{
    public class StockHelper
    {
        public static string GetMaterialName(string stock)
        {
            var splitedValues = SplitStock(stock);

            return splitedValues[0];
        }

        public static int GetPropertyCount(string stock)
        {
            var splitedValues = SplitStock(stock);

            return splitedValues.Length;
        }

        public static string GetMaterialID(string stock)
        {
            var splitedValues = SplitStock(stock);

            return splitedValues[1];
        }
        public static string GetMaterialAmount(string stock)
        {
            var splitedValues = SplitStock(stock);
            return stock.Split(',')[1];
        }
        public static string GetWarehouseName(string stock)
        {
            var splitedValues = SplitStock(stock);
            return stock.Split(',')[0];
        }

        public static string[] GetWarehouses(string stock)
        {
            var splitedValues = SplitStock(stock);
            return splitedValues[2].Split('|');
        }

        private static string[] SplitStock(string stock)
        {
            return stock.Split(';');
        }
    }
}
