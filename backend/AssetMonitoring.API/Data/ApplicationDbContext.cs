using AssetMonitoring.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetMonitoring.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<AssetAlert> AssetAlerts { get; set; }
    }
}