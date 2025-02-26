using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Model;

namespace WarehouseAccountingAPI.Controllers
{
    public class WarehouseGet
    { 
        public int IdWarehouse { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string WarehouseType { get; set; }
        public string StorageArea { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WarehouseController(ApplicationDbContext context)
        { 
            _context = context;
        }

        [HttpGet("Warehouse")]
        public async Task<IActionResult> GetWarehouse()
        {
            var warehouseData = await (from warehouse in _context.Warehouse
                                 join warehouseType in _context.WarehouseType on warehouse.IdWarehouseType equals warehouseType.IdWarehouseType
                                 join storageArea in _context.StorageArea on warehouse.IdStorageArea equals storageArea.IdStorageArea
                                 select new WarehouseGet
                                 {
                                     IdWarehouse = warehouse.IdWarehouse,
                                     Title = warehouse.Title,   
                                     Address = warehouse.Address,
                                     WarehouseType = warehouseType.Title,
                                     StorageArea = storageArea.Title
                                 }).ToListAsync();
            

            return Ok(warehouseData);
        }
    }
}
