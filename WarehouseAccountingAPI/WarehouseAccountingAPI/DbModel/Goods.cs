using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class Goods
    {
        [Key]
        public int IdGoods { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Barcode { get; set; }
        [ForeignKey("Category")]
        [Column("IdCategory")]
        [MaybeNull]
        public int? IdCategory { get; set; }
        [ForeignKey("Unit")]
        [Column("IdUnit")]
        [MaybeNull]
        public int? IdUnit { get; set; }
        public float Price { get; set; }
        public string SerialNumber { get; set; }
        public float MinimumBalance { get; set; }
    }
}
