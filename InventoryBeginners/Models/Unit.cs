﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryBeginners.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(50)]
        public string Name { get; set; }    
    
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
