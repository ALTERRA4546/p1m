using Microsoft.EntityFrameworkCore;

namespace WarehouseAccounting.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
        : base(option)
        {
        
        }

        public DbSet<AuthorizationEmployee> AuthorizationEmployee { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ExpenditureInvoice> ExpenditureInvoice { get; set; }
        public DbSet<ExpenditureInvoiceWarehouse> ExpenditureInvoiceWarehouse { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsWarehouse> GoodsWarehouse { get; set; }
        public DbSet<IncomingInvoice> IncomingInvoice { get; set; }
        public DbSet<IncomingInvoiceWarehouse> IncomingInvoiceWarehouse { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryWarehouse> InventoryWarehouse { get; set; }
        public DbSet<StorageArea> StorageArea { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WarehouseType> WarehouseType { get; set; }
    }
}
