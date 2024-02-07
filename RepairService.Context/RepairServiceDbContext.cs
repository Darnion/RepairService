using System.Data.Entity;

namespace RepairService.Context
{
    public class RepairServiceDbContext : DbContext
    {
        public RepairServiceDbContext() : base("RepairServiceDbConnectionString")
        {

        }


    }
}
