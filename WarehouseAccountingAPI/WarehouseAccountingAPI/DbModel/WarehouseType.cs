using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class WarehouseType
    {
        [Key]
        public int IdWarehouseType { get; set; }
        public string Title { get; set; }
    }
}
