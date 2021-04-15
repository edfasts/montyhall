using System;
using Microsoft.EntityFrameworkCore;
using MontyHall.Core.Models;
using MontyHall.Data.Configurations;

namespace MontyHall.Data
{
    public class MontyHallDbContext : DbContext
    {
        public DbSet<Simulation> Simulations { get; set; }

        public MontyHallDbContext(DbContextOptions<MontyHallDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SimulationConfiguration());
        }
    }
}