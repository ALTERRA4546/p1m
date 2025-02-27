using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingDLL;

namespace DLLTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var res = await UserAuthorization.SetAuthorizationVerifyCode("https://localhost:7284/api/UserAuthorization/AuthorizationV2_Verify_Code", "kordroy20@mail.ru", "3442");

            string apiUrl = "https://localhost:7284/api/GoodsInWarehouse/Goods";
            List<QuantityOfGoods> warehouses = await QuantityOfGoods.LoadWarehousesFromApi(apiUrl);

            Console.WriteLine("Список складов и количество товаров на каждом складе:");
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine($"{warehouse.TitleWarehouse} - товаров {warehouse.GetItemCount()}");
            }

            double totalItemCount = QuantityOfGoods.GetTotalItemCount(warehouses);
            Console.WriteLine($"\nОбщее количество товаров по складам: {totalItemCount}");

            Console.WriteLine("\nСумма стоимости товаров на каждом складе:");
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine($"{warehouse.TitleWarehouse} - сумма стоимости товаров {warehouse.GetTotalValue()} Руб");
            }

            double totalValue = QuantityOfGoods.GetTotalValue(warehouses);
            Console.WriteLine($"\nОбщая сумма стоимости товаров по складам: {totalValue} Руб");

            Console.WriteLine("\nКоличество товаров по категориям на каждом складе:");
            foreach (var warehouse in warehouses)
            {
                var itemCountByCategory = warehouse.GetItemCountByCategory();
                Console.WriteLine($"{warehouse.TitleWarehouse}:");
                foreach (var category in itemCountByCategory)
                {
                    Console.WriteLine($"  {category.Key}: {category.Value}");
                }
            }

            var totalItemCountByCategory = QuantityOfGoods.GetTotalItemCountByCategory(warehouses);
            Console.WriteLine("\nОбщее количество товаров по категориям по складам:");
            foreach (var category in totalItemCountByCategory)
            {
                Console.WriteLine($"{category.Key}: {category.Value}");
            }
        }
    }
}
