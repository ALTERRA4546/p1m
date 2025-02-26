using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class InventoryWarehouse
    {
        [Key]
        public int IdInventoryWarehouse { get; set; }
        [ForeignKey("Intentory")]
        [Column("IdIntentory")]
        [MaybeNull]
        public int? IdIntentory { get; set; }
        [ForeignKey("Warehouse")]
        [Column("IdWarehouse")]
        public int? IdWarehouse { get; set; }
        public float AccountingQuantity { get; set; }
        public float ActualQuantity { get; set; }
    }
}
