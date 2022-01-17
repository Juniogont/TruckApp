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

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(string.Format("Server = {0}; Database = TruckApp; Integrated Security=SSPI; ", Environment.MachineName + @"\SQLEXPRESS"));

        public DbSet<Caminhao> Caminhao { get; set; }
    }
}
