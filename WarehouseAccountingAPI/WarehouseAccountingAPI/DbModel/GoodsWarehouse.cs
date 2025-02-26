using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class GoodsWarehouse
    {
        [Key]
        public int IdGoodsWarehouse { get; set; }
        [ForeignKey("Goods")]
        [Column("IdGoods")]
        [MaybeNull]
        public int? IdGoods { get; set; }
        [ForeignKey("Warehouse")]
        [Column("IdWarehouse")]
        [MaybeNull]
        public int? IdWarehouse { get; set; }
    }
}
