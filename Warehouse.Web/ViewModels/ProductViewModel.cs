using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [StringLength(128)]
        public string Description { get; set; }
    }
}