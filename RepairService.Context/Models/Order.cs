using System;
using System.Collections.Generic;

namespace RepairService.Context.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int TypeBrokenId { get; set; }
        public TypeBroken TypeBroken { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public ICollection<User> Workers { get; set; }
        public Order()
        {
            Workers = new HashSet<User>();
        }
        public ICollection<Report> Reports { get; set; }
    }
}
