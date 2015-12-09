using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataStoring.EF;

namespace DataStoring.EF.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20151208150406_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bremacon.CorePersonManager.CrossCutting.DataClasses.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age")
                        .HasAnnotation("Relational:ColumnName", "Age");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "Firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "Lastname");

                    b.HasKey("ID");
                });
        }
    }
}
