using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseAccounting.Model
{
    public class AuthorizationEmployee
    {
        [Key]
        public int IdAuthorizationEmployee { get; set; }
        [ForeignKey("Employee")]
        [Column("IdEmployee")]
        [MaybeNull]
        public int? IdEmployee { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string KeyWord { get; set; }
    }
}
