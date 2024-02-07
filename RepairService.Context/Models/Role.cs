using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}