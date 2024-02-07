﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class TypeBroken
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
