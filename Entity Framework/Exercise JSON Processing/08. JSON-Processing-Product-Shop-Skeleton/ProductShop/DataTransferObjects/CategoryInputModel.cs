using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DataTransferObjects
{
    public class CategoryInputModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
