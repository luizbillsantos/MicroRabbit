using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {

        public TransferDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TransferLog>().ToTable("TransferLog").HasKey(a => a.Id);

        }

        public DbSet<TransferLog> TransferLog { get; set; }

    }
}
