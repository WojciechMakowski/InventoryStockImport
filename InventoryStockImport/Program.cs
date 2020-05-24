using System;
using System.Diagnostics;
using InventoryStockImport.BLL.Abstracts;
using InventoryStockImport.BLL.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryStockImport
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            string path = "";

            if (args.Length == 0)
            {
                Console.WriteLine("Podaj ścieżę plik wejściowy");
                path = Console.ReadLine();
            }

            RegisterServices();

            var fileService = _serviceProvider.GetService<IImportService>();
            var sortService = _serviceProvider.GetService<ISortService>();
            var printService = _serviceProvider.GetService<IPrintService>();
            
            var stocks = fileService.ImportStocks(path);
            
            sortService.SortMaterials(stocks);
            var sortedStocks = sortService.SortWarehouses(stocks);

            printService.PrintWarehouses(sortedStocks);

            DisposeServices();
            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IImportService, ImportService>();
            collection.AddScoped<IStockBLL, StockBLL>();
            collection.AddScoped<IValidationService, ValidationService>();
            collection.AddScoped<IPrintService, PrintService>();
            collection.AddScoped<ISortService, SortService>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
