using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class Unit
    {
        [Key]
        public int IdUnit { get; set; }
        public string Title { get; set; }
    }
}
