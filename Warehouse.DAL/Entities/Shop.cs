using System.ComponentModel.DataAnnotations;

namespace Warehouse.DAL.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Title { get; set; }
        [StringLength(128)]
        public string Address { get; set; }
        [StringLength(128)]
        public string Schedule { get; set; }
    }
}
