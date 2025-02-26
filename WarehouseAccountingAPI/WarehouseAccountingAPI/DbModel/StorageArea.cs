using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class StorageArea
    {
        [Key]
        public int IdStorageArea { get; set; }
        public string Title { get; set; }
    }
}
