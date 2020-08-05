using Microsoft.EntityFrameworkCore;
using Recodme.Dxs.DesafioDXS.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Dxs.DesafioDXS.DataAccessLayer.Contexts
{
    public class PyramidContext : DbContext
    {
        public PyramidContext() : base() { }

        public PyramidContext(DbContextOptions options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        public DbSet<Pyramid> Pyramids { get; set; }
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<Sarcophagus> Sarcophagi { get; set; }

    }
}
