﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellsDTO
    {
       
        [Required]
        [StringLength(25, MinimumLength =3)]
        public string Name { get; set; }

        public ICollection<CellsDTO>  Cells { get; set; }
    }
}
