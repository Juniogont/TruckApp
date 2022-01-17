using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Truck.Domain.Entities;

namespace Truck.Infra.Data
{
    public class TruckDbContext : DbContext
    {
        public TruckDbContext(DbContextOptions<TruckDbContext> opcoes)
            : base(opcoes)
        {
        }
        public TruckDbContext()
      : base()
        {
        }
  
        public DbSet<Caminhao> Caminhao { get; set; }
    }
}
