﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocky.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name  { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order for category must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
