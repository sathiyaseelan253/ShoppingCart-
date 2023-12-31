﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCart.services.CoupenAPI.Data;

#nullable disable

namespace ShoppingCart.services.CoupenAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230807113551_SeedDataToDB")]
    partial class SeedDataToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingCart.services.CoupenAPI.Models.Coupen", b =>
                {
                    b.Property<int>("CoupenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoupenId"));

                    b.Property<string>("CoupenCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CoupenId");

                    b.ToTable("Coupen");

                    b.HasData(
                        new
                        {
                            CoupenId = 1,
                            CoupenCode = "Coupen1",
                            DiscountAmount = 100m,
                            MinAmount = 400
                        },
                        new
                        {
                            CoupenId = 2,
                            CoupenCode = "Coupen3",
                            DiscountAmount = 90m,
                            MinAmount = 872
                        },
                        new
                        {
                            CoupenId = 3,
                            CoupenCode = "Coupen3",
                            DiscountAmount = 98m,
                            MinAmount = 748
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
