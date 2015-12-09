using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;

using Configuration.Contracts;

using Microsoft.Data.Entity;

namespace DataStoring.EF
{
    public class StorageContext : DbContext
    {
        private readonly IConfigurator _configurator;
        private readonly string _connectionString;
        public DbSet<Person> Persons { get; set; }

        public StorageContext()
        {
            _connectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=BCKontaktManager;Integrated Security=True";
        }

        public StorageContext(IConfigurator configurator)
        {
            _configurator = configurator;
            _connectionString = _configurator.Get<string>("Database", "ConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personTbl = modelBuilder
                .Entity<Person>();

            personTbl.Property(p => p.Firstname)
                .HasColumnName("Firstname")
                .IsRequired();
            personTbl.Property(p => p.Lastname)
                .HasColumnName("Lastname")
                .IsRequired();
            personTbl.Property(p => p.Age)
                .HasColumnName("Age")
                .IsRequired();
            personTbl.HasKey(p => p.ID);
        }
    }
}
