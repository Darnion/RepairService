using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<Order> OrderClients { get; set; }
        public virtual ICollection<Order> OrderWorkers { get; set; }
        public User()
        {
            OrderWorkers = new HashSet<Order>();
        }
    }
}
