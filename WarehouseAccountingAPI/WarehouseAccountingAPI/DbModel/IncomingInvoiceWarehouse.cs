using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class IncomingInvoiceWarehouse
    {
        [Key]
        public int IdIncomingInvoiceWarehouse { get; set; }
        [ForeignKey("IncomingInvoice")]
        [Column("IdIncomingInvoice")]
        [MaybeNull]
        public int? IdIncomingInvoice { get; set; }
        [ForeignKey("Warehouse")]
        [Column("IdWarehouse")]
        [MaybeNull]
        public int? IdWarehouse { get; set; }
    }
}
