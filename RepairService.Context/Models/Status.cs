using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
