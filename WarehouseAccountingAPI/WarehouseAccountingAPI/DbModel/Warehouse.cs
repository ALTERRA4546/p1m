using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class Warehouse
    {
        [Key]
        public int IdWarehouse { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        [ForeignKey("WarehouseType")]
        [Column("IdWarehouseType")]
        [MaybeNull]
        public int? IdWarehouseType { get; set; }
        [ForeignKey("StorageArea")]
        [Column("IdStorageArea")]
        [MaybeNull]
        public int? IdStorageArea { get; set; }
    }
}
