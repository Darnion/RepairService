using System;
using System.Collections.Generic;

namespace RepairService.Context.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public int ClientId { get; set; }
        public virtual User Client { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public int TypeBrokenId { get; set; }
        public virtual TypeBroken TypeBroken { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public virtual ICollection<User> Workers { get; set; }
        public Order()
        {
            Workers = new HashSet<User>();
        }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
