using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerApp.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductNo { get; set; }
        public string Description { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
