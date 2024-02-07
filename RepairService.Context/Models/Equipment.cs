using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
