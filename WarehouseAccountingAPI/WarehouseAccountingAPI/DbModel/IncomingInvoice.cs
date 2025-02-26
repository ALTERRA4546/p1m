using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class IncomingInvoice
    {
        [Key]
        public int IdIncomingInvoice { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateReceipt { get; set; }
        [ForeignKey("Supplier")]
        [Column("IdSupplier")]
        [MaybeNull]
        public int? IdSupplier { get; set; }
        public float TotalPrice { get; set; }
    }
}
