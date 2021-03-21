using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControllerApp.Dto
{
    public class ProductGroupDto
    {
        [Required]
        public int ProductGroupDtoId { get; set; }
        public string Name { get; set; }
    }
   
}
