using InventoryStockImport.BLL.Concrete;
using InventoryStockImport.BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace InventoryStockImportTest
{
    public class StockSorterTest
    {
        [Fact]
        public void ValidSortMaterials()
        {
            //Arrange
            var stockSortService = new SortService();

            List<Material> materials = new List<Material>();

            Material firstMaterial = new Material();
            firstMaterial.MaterialId = "COM-123906c";
            firstMaterial.Amount = 10;
            firstMaterial.Name = "Generic Wire Pull";

            Material secondMaterial = new Material();
            secondMaterial.MaterialId = "COM-100001";
            secondMaterial.Amount = 10;
            secondMaterial.Name = "Cherry Hardwood Arched Door - PS";

            materials.Add(firstMaterial);
            materials.Add(secondMaterial);

            Warehouse warehouse = new Warehouse();
            warehouse.Name = "WH-A";
            warehouse.Materials = materials;

            //Act
            stockSortService.SortMaterials(new Dictionary<string, Warehouse>() { { warehouse.Name, warehouse } });

            //Assert
            Assert.Equal(warehouse.Materials.FirstOrDefault(), secondMaterial);
        }

        [Fact]
        public void ValidSortWarehouses()
        {
            //Arrange
            var stockSortService = new SortService();

            IDictionary<string, Warehouse> warehouses = new Dictionary<string, Warehouse>();

            Warehouse firstWarehouse = new Warehouse();
            firstWarehouse.Name = "WH-A";
            firstWarehouse.Materials = new List<Material>()
            {
                new Material() { Amount = 10, MaterialId = "COM-100001", Name = "Cherry Hardwood Arched Door - PS" },
                new Material() { Amount = 10, MaterialId = "COM-123906c", Name = "Generic Wire Pull;" }
            };

            Warehouse secondWarehouse = new Warehouse();
            secondWarehouse.Name = "WH-B";
            secondWarehouse.Materials = new List<Material>()
            {
                new Material() { Amount = 10, MaterialId = "COM-100001", Name = "Cherry Hardwood Arched Door - PS" }
            };

            Warehouse thirdWarehouse = new Warehouse();
            thirdWarehouse.Name = "WH-C";
            thirdWarehouse.Materials = new List<Material>()
            {
                new Material() { Amount = 10, MaterialId = "COM-100001", Name = "Cherry Hardwood Arched Door - PS" }
            };

            warehouses.Add(firstWarehouse.Name, firstWarehouse);
            warehouses.Add(secondWarehouse.Name, secondWarehouse);
            warehouses.Add(thirdWarehouse.Name, thirdWarehouse);

            //Act
            var sortedwareHouses = stockSortService.SortWarehouses(warehouses);

            //Assert
            Assert.Equal(sortedwareHouses.Skip(1).Take(1).FirstOrDefault().Value, thirdWarehouse);
        }
    }
}
