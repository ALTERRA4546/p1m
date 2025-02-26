using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class ExpenditureInvoiceWarehouse
    {
        [Key]
        public int IdExpenditureInvoiceWarehouse { get; set; }
        [ForeignKey("ExpenditureInvoice")]
        [Column("IdExpenditureInvoice")]
        [MaybeNull]
        public int? IdExpenditureInvoice { get; set; }
        [ForeignKey("Warehouse")]
        [Column("IdWarehouse")]
        [MaybeNull]
        public int? IdWarehouse { get; set; }
    }
}
