using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}