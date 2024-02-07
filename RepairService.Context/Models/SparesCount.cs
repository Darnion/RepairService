using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepairService.Context.Models
{
    public class SparesCount
    {
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        public int SparesTypeId { get; set; }
        public virtual SparesType SparesType { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public SparesCount()
        {
            Reports = new HashSet<Report>();
        }
    }
}
