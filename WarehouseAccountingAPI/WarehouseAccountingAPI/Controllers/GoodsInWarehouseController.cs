using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Model;

namespace WarehouseAccounting.Controllers
{
    public class GoodsGet
    {
        public int IdGoods { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public string? SerialNumber { get; set; }
        public double? MinimumBalance { get; set; }
        public Warehouse Warehouse { get; set; }
    }

    public class GoodsSet
    {
        public int IdWarehouse { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Barcode { get; set; }
        public int IdCategory { get; set; }
        public int IdUnit { get; set; }
        public float Price { get; set; }
        public string SerialNumber { get; set; }
        public float MinimumBalance { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class GoodsInWarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GoodsInWarehouseController(ApplicationDbContext context)
        { 
            _context = context;
        }

        [HttpGet("Goods")]
        public async Task<IActionResult> GetGoods()
        {
                var goodsData = await (from goods in _context.Goods
                                       join category in _context.Category on goods.IdCategory equals category.IdCategory
                                       join unit in _context.Unit on goods.IdUnit equals unit.IdUnit
                                       join goodsWarehouse in _context.GoodsWarehouse on goods.IdGoods equals goodsWarehouse.IdGoods
                                       join warehouse in _context.Warehouse on goodsWarehouse.IdWarehouse equals warehouse.IdWarehouse
                                       select new GoodsGet
                                       {
                                           IdGoods = goods.IdGoods,
                                           Title = goods.Title,
                                           Article = goods.Article,
                                           Barcode = goods.Barcode,
                                           Category = category.Title,
                                           Unit = unit.Title,
                                           Price = goods.Price,
                                           SerialNumber = goods.SerialNumber ?? "N/A",
                                           MinimumBalance = goods.MinimumBalance,
                                           Warehouse = warehouse
                                       }).ToListAsync();
                
                return Ok(goodsData);
        }

        [HttpPost("Goods")]
        public async Task<IActionResult> SetGoods([FromBody] GoodsSet goodsSet)
        {
            var goods = new Goods
            {
                Title = goodsSet.Title,
                Article = goodsSet.Article,
                Barcode = goodsSet.Barcode,
                IdCategory = goodsSet.IdCategory,
                IdUnit = goodsSet.IdUnit,
                Price = goodsSet.Price,
                SerialNumber = goodsSet.SerialNumber,
                MinimumBalance = goodsSet.MinimumBalance
            };

            _context.Goods.Add(goods);

            var goodsWarehouse = new GoodsWarehouse
            {
                IdGoods = goods.IdGoods,
                IdWarehouse = goodsSet.IdWarehouse
            };

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
