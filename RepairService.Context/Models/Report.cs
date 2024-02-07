using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairService.Context.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Price { get; set; }
        public DateTimeOffset CompletionTime { get; set; } = DateTimeOffset.Now;
        public string Reason { get; set; }
        public virtual ICollection<SparesCount> Spares { get; set; }
        public Report()
        {
            Spares = new HashSet<SparesCount>();
        }
    }
}
