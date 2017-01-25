using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.DAL.Entities
{
    public class ProductInTheShop
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ShopId { get; set; }

        public Product Product { get; set; }

        public Shop Shop { get; set; }
    }
}