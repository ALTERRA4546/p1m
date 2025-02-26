using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class Supplier
    {
        [Key]
        public int IdSupplier { get; set; }
        public string Title { get; set; }
        public string INNOrKPP { get; set; }
        public string Address { get; set; }
    }
}
