using ClassicGarage.Models;
using System.Data.Entity;

namespace ClassicGarage.DAL
{
    public class GarageContext : DbContext
    {
        public GarageContext (): base("GarageDatabase") { }
        public DbSet<CarModels> Car { get; set; }
        public DbSet<OwnerModels> Owner { get; set; }
        public DbSet<PartsModels> Part { get; set; }
        public DbSet<RepairModels> Repair { get; set; }
        public DbSet<AnnouncementsModels> Announcements { get; set; }
    }
}