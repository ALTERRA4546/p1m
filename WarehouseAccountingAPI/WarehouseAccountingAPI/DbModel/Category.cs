using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public string Title { get; set; }
    }
}
