
using ControllerApp.Domains;

namespace TenderSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductNo { get; set; }
        public string Description { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
    }
}
