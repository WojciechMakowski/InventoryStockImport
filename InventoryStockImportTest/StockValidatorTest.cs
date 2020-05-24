using InventoryStockImport.BLL.Concrete;
using System;
using Xunit;

namespace InventoryStockImportTest
{
    public class StockValidatorTest
    {
        [Fact]
        public void ValidStock()
        {
            //Arrange
            var stockValidationService = new ValidationService();
            string stock = "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10";

            //Act
            bool isValid = stockValidationService.ValidateRawStock(stock);

            //Assert
            Assert.True(isValid, $"Stock is not valid - stock: {stock}");
        }

        [Fact]
        public void NotValidStock()
        {
            //Arrange
            var stockValidationService = new ValidationService();
            string stock = ";COM-100001;WH-A,5|WH-B,10";

            //Act
            bool isValid = stockValidationService.ValidateRawStock(stock);

            //Assert
            Assert.False(isValid, $"stock should not be valid! - stock: {stock}");
        }
    }
}
