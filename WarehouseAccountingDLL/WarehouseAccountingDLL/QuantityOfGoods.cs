using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAccountingDLL
{
    public class GoodsWarehouse
    {
        public int IdGoods { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public string SerialNumber { get; set; }
        public double MinimumBalance { get; set; }
        public double Quantity { get; set; }
        public int IdWarehouse { get; set; }
        public string TitleWarehouse { get; set; }
        public string AddressWarehouse { get; set; }
        public string WarehouseType { get; set; }
        public string StorageArea { get; set; }
    }

    public class QuantityOfGoods
    {
        public int IdWarehouse { get; set; }
        public string TitleWarehouse { get; set; }
        public string AddressWarehouse { get; set; }
        public string WarehouseType { get; set; }
        public string StorageArea { get; set; }
        public List<GoodsWarehouse> Items { get; set; }

        public QuantityOfGoods(int idWarehouse, string titleWarehouse, string addressWarehouse, string warehouseType, string storageArea)
        {
            IdWarehouse = idWarehouse;
            TitleWarehouse = titleWarehouse;
            AddressWarehouse = addressWarehouse;
            WarehouseType = warehouseType;
            StorageArea = storageArea;
            Items = new List<GoodsWarehouse>();
        }
        //
        public static int GetTotalItemCount(List<QuantityOfGoods> warehouses)
        {
            return warehouses.Sum(warehouse => warehouse.Items.Count);
        }

        public int GetItemCount()
        {
            return Items.Count;
        }

        /*public double GetTotalValue()
        {
            return Items.Sum(item => item.Price);
        }

        public static double GetTotalValue(List<QuantityOfGoods> warehouses)
        {
            return warehouses.Sum(warehouse => warehouse.GetTotalValue());
        }*/

        public Dictionary<string, int> GetItemCountByCategory()
        {
            return Items.GroupBy(item => item.Category)
                        .ToDictionary(group => group.Key, group => group.Count());
        }

        public static Dictionary<string, int> GetTotalItemCountByCategory(List<QuantityOfGoods> warehouses)
        {
            var result = new Dictionary<string, int>();
            foreach (var warehouse in warehouses)
            {
                var categoryCounts = warehouse.GetItemCountByCategory();
                foreach (var category in categoryCounts.Keys)
                {
                    if (result.ContainsKey(category))
                    {
                        result[category] += categoryCounts[category];
                    }
                    else
                    {
                        result[category] = categoryCounts[category];
                    }
                }
            }
            return result;
        }
        //
        /*public static double GetTotalItemCount(List<QuantityOfGoods> warehouses)
        {
            return warehouses.Sum(warehouse => warehouse.Items.Sum(item => item.Quantity));
        }

        public double GetItemCount()
        {
            return Items.Sum(item => item.Quantity);
        }*/

        public double GetTotalValue()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }


        public static double GetTotalValue(List<QuantityOfGoods> warehouses)
        {
            return warehouses.Sum(warehouse => warehouse.GetTotalValue());
        }

        /*public Dictionary<string, double> GetItemCountByCategory()
        {
            return Items.GroupBy(item => item.Category)
                        .ToDictionary(group => group.Key, group => group.Sum(item => item.Quantity));
        }

        public static Dictionary<string, double> GetTotalItemCountByCategory(List<QuantityOfGoods> warehouses)
        {
            var result = new Dictionary<string, double>();
            foreach (var warehouse in warehouses)
            {
                var categoryCounts = warehouse.GetItemCountByCategory();
                foreach (var category in categoryCounts.Keys)
                {
                    if (result.ContainsKey(category))
                    {
                        result[category] += categoryCounts[category];
                    }
                    else
                    {
                        result[category] = categoryCounts[category];
                    }
                }
            }
            return result;
        }*/

        public static async Task<List<QuantityOfGoods>> LoadWarehousesFromApi(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var goods = await client.GetFromJsonAsync<List<GoodsWarehouse>>(apiUrl);
                var warehouses = goods.GroupBy(g => g.IdWarehouse)
                                      .Select(g => new QuantityOfGoods(
                                          g.Key,
                                          g.First().TitleWarehouse,
                                          g.First().AddressWarehouse,
                                          g.First().WarehouseType,
                                          g.First().StorageArea
                                      )
                                      {
                                          Items = g.ToList()
                                      })
                                      .ToList();
                return warehouses;
            }
        }
    }
}
