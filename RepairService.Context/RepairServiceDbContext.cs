using RepairService.Context.Models;
using System.Data.Entity;

namespace RepairService.Context
{
    public class RepairServiceDbContext : DbContext
    {
        public RepairServiceDbContext() : base("RepairServiceDbConnectionString")
        {

        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SparesCount> SparesCounts { get; set; }
        public DbSet<SparesType> SparesTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TypeBroken> TypeBrokens { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(x => x.OrderWorkers)
                .WithMany(x => x.Workers);

            
        }
    }
}
