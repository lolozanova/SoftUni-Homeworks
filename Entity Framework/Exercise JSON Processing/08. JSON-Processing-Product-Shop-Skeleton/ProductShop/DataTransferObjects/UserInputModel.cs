using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DataTransferObjects
{
    public class UserInputModel
    {
        public string FirstName { get; set; }

        [Required]
        [MinLength (3)]
        public string LastName  { get; set; }

        public int? Age { get; set; }
    }
}
