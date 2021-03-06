using Microsoft.EntityFrameworkCore;
using System;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<ZooKeeper> ZooKeepers { get; set; }
    }
}