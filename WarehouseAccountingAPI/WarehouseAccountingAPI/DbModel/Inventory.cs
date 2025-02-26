using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class Inventory
    {
        [Key]
        public int IdInventory { get; set; }
        public DateTime DateEvent { get; set; }
        [ForeignKey("Employee")]
        [Column("IdResponsible")]
        [MaybeNull]
        public int? IdResponsible { get; set; }
        public string Result { get; set; }
    }
}
