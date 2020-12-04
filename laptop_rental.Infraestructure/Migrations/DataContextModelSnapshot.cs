﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using laptoprental.Persistence.Contexts;

namespace laptop_rental.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("laptop_rental.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("cnpj")
                        .HasColumnType("text");

                    b.Property<string>("cpf")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isLegal")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("dailyLateFee")
                        .HasColumnType("numeric");

                    b.Property<decimal>("dailyPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("stockAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("customerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("fullPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("rentDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rentExpirationDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.RentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("laptopId")
                        .HasColumnType("integer");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("rentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("laptopId");

                    b.HasIndex("rentId");

                    b.ToTable("RentItems");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.Rent", b =>
                {
                    b.HasOne("laptop_rental.Domain.Models.Customer", "customer")
                        .WithMany("rent")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.RentItem", b =>
                {
                    b.HasOne("laptop_rental.Domain.Models.Laptop", "laptop")
                        .WithMany("items")
                        .HasForeignKey("laptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("laptop_rental.Domain.Models.Rent", "rent")
                        .WithMany("items")
                        .HasForeignKey("rentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("laptop");

                    b.Navigation("rent");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.Customer", b =>
                {
                    b.Navigation("rent");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.Laptop", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("laptop_rental.Domain.Models.Rent", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}