using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class ExpenditureInvoice
    {
        [Key]
        public int IdExpenditureInvoice { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime ShipmentDate { get; set; }
        public float TotalPrice { get; set; }
        [ForeignKey("Client")]
        [Column("IdClient")]
        [MaybeNull]
        public int? IdClient { get; set; }
    }
}
