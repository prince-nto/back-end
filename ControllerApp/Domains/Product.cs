
using ControllerApp.Dto;

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
        public virtual ProductGroupDto ProductGroup { get; set; }
    }
}
